using System;
using System.Collections.Generic;

namespace TurističkaAgencija.Models
{
    public partial class Drzava
    {
        public Drzava()
        {
            Destinacija = new HashSet<Destinacija>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Destinacija> Destinacija { get; set; }
    }
}
