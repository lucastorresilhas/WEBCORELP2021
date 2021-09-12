using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBCORELP2021.Models.Dominio
{
    public class Consulta
    {
        public Medico medico { get; set; }
        public Paciente paciente { get; set; }

        public int id { get; set; }
        public string descricao { get; set; }
    }
}
