using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WEBCORELP2021.Models.Dominio
{
    [Table("Pacientes")]
    public class Paciente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("ID")]
        public int id { get; set; }
        [StringLength(35)]
        [DisplayName("Paciente")]
        [Required(ErrorMessage ="Campo Obrigatório!")]
        public string nome { get; set; }

        public string cidade { get; set; }
        public int idade { get; set; }
        public string endereco { get; set; }
        public ICollection<PlanoDeSaude> planoDeSaude { get; set; }
        public ICollection<Consulta> consultas { get; set; }
    }
}
