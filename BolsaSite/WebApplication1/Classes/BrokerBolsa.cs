using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WebApplication1
{
    class BrokerBolsa
    {
        private static string EXCHANGE = "BOLSADEVALORES";
        private static String codigo = null;

        // RECEBE NOTIFICAÇÕES
        public static void receber(String[] topicos)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.ExchangeDeclare(EXCHANGE, "topic");
            string queueName = channel.QueueDeclare().QueueName;


            if (topicos.Length < 1)
            {
                Console.Error.WriteLine("Erro");
                Environment.Exit(1);
            }

            foreach (String bindingKey in topicos)
            {
                channel.QueueBind(queueName, EXCHANGE, bindingKey);
            }

            Console.WriteLine("MONITORANDO. Para parar pressione CTRL+C");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                if (!codigo.Contains("info") && ea.RoutingKey.Contains("info"))
                {

                }
                else
                {
                    Console.WriteLine("Recebida: '" + ea.RoutingKey + "_<" + message + ">'");
                    codigo = "";
                }
            };
            channel.BasicConsume(queue: "BROKER",
                                 autoAck: true,
                                 consumer: consumer);
        }

        // REQUISITA OPERAÇÕES
        public static void enviar(String[] operacao)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("BROKER", true, false, false, null);

            string message = "";
            if (operacao.Length < 1)
                message = "Anonimo";
            else
                message = operacao[0];

            if (operacao.Length < 2)
                message += "_" + "Nada";
            else
                message += "_" + juntasStrings(operacao, ";", 1);
            channel.BasicPublish("", "BROKER", null, Encoding.UTF8.GetBytes(message));

            Console.WriteLine("Enviada: '<" + message + ">'");
        }

        // AUXILIAR
        private static string juntasStrings(String[] strings, String delimitador, int startIndex)
        {
            int length = strings.Length;
            if (length == 0)
                return "";
            if (length < startIndex)
                return "";
            StringBuilder words = new StringBuilder(strings[startIndex]);
            for (int i = startIndex + 1; i < length; i++)
            {
                words.Append(delimitador).Append(strings[i]);
            }
            return words.ToString();
        }

        private static void thread()
        {
            try
            {
                receber(new String[] { codigo });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

    }
}
