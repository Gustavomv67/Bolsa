using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Broker.Models
{
    public class Ação
    {
        [Key]
        [DisplayName("Codigo da ação")]
        [Required(ErrorMessage = "Informe o codigo da ação")]
        public string codigo { get; set; }

        [DisplayName("Nome da ação")]
        [Required(ErrorMessage = "Informe o nome da ação")]
        public string nome { get; set; }

        [DisplayName("Descrição da ação")]
        [Required(ErrorMessage = "Informe a descrição da ação")]
        public string descricao { get; set; }
    }
}