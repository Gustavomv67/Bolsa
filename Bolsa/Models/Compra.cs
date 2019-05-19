using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bolsa.Models
{
    public class Compra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [DisplayName("Valor")]
        [Required(ErrorMessage = "Informe o valor da ação")]
        public float valor { get; set; }

        [DisplayName("Quantidade")]
        [Required(ErrorMessage = "Informe a quantidade da ação")]
        public float quantidade { get; set; }

        [DisplayName("Ação")]
        public Ação acao { get; set; }
    }
}