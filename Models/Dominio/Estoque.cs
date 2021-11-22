using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WEBCORELP2021.Models.Dominio
{
    [Table("Estoque")]
    public class Estoque
    {
        [Key]
        [DisplayName("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [DisplayName("Descricao")]
        [StringLength(45, ErrorMessage = "Tamanho inválido.", MinimumLength = 5)]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string nome { get; set; }

        [DisplayName("Quantidade")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int idade { get; set; }

        public ICollection<Consulta> consultas { get; set; }
    }
}
