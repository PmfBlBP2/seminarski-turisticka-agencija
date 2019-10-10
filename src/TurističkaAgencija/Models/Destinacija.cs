﻿using System;
using System.Collections.Generic;

namespace TurističkaAgencija.Models
{
    public partial class Destinacija
    {
        public Destinacija()
        {
            Ponuda = new HashSet<Ponuda>();
            Smjestaj = new HashSet<Smjestaj>();
        }

        public int Id { get; set; }
        public int DrzavaId { get; set; }
        public string Grad { get; set; }
        public string Opis { get; set; }
        public string Slika { get; set; }

        public virtual Drzava Drzava { get; set; }
        public virtual ICollection<Ponuda> Ponuda { get; set; }
        public virtual ICollection<Smjestaj> Smjestaj { get; set; }
    }
}
