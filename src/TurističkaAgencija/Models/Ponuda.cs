using System;
using System.Collections.Generic;

namespace TurističkaAgencija.Models
{
    public partial class Ponuda
    {
        public Ponuda()
        {
            Rezervacija = new HashSet<Rezervacija>();
        }

        public int Id { get; set; }
        public int SmjestajId { get; set; }
        public int DestinacijaId { get; set; }
        public int PrevozId { get; set; }
        public string Naziv { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }
        public decimal Cijena { get; set; }

        public virtual Destinacija Destinacija { get; set; }
        public virtual Prevoz Prevoz { get; set; }
        public virtual Smjestaj Smjestaj { get; set; }
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
    }
}
