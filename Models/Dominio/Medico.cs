using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBCORELP2021.Models.Dominio
{
    public class Medico
    {
        public ICollection<Consulta> consultas { get; set; }
        public int id { get; set; }
        public string nome { get; set; }
        public string idade { get; set; }
        public string cidade { get; set; }
        public string numero { get; set; }
    }
}
