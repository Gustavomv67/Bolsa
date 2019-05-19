using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bolsa.Models
{
    public class Info
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [DisplayName("Ação")]
        public Ação acao { get; set; }

        [DisplayName("Data")]
        [Required(ErrorMessage = "Escolha a data")]
        public DateTime data { get; set; }
    }
}