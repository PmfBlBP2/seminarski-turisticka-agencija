using System;
using System.Collections.Generic;

namespace TurističkaAgencija.Models
{
    public partial class Kompanija
    {
        public Kompanija()
        {
            Prevoz = new HashSet<Prevoz>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Grad { get; set; }

        public virtual ICollection<Prevoz> Prevoz { get; set; }
    }
}
