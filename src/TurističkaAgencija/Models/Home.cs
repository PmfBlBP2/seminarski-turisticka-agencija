using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurističkaAgencija.Models
{
    public class Home
    {
        public IEnumerable<Ponuda> Ponuda { get; set; }
        public Ponuda JednaPonuda { get; set; }
        public IEnumerable<Ponuda> TopTri { get; set; }
        public Pretraga Pretraga { get; set; }
    }
}
