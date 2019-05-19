using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

public class BrokerContext : DbContext
{
    // You can add custom code to this file. Changes will not be overwritten.
    // 
    // If you want Entity Framework to drop and regenerate your database
    // automatically whenever you change your model schema, please use data migrations.
    // For more information refer to the documentation:
    // http://msdn.microsoft.com/en-us/data/jj591621.aspx

    public BrokerContext() : base("name=BrokerContext")
    {
    }

    public System.Data.Entity.DbSet<Broker.Models.Ação> Ação { get; set; }

    public System.Data.Entity.DbSet<Broker.Models.Compra> Compras { get; set; }

    public System.Data.Entity.DbSet<Broker.Models.Venda> Vendas { get; set; }

    public System.Data.Entity.DbSet<Broker.Models.Info> Infoes { get; set; }
}
