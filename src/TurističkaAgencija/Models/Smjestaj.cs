using System;
using System.Collections.Generic;

namespace TurističkaAgencija.Models
{
    public partial class Smjestaj
    {
        public Smjestaj()
        {
            Ponuda = new HashSet<Ponuda>();
        }

        public int Id { get; set; }
        public int DestinacijaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Adresa { get; set; }
        public string Slika { get; set; }

        public virtual Destinacija Destinacija { get; set; }
        public virtual ICollection<Ponuda> Ponuda { get; set; }
    }
}
