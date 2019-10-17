using System;
using System.Collections.Generic;

namespace TurističkaAgencija.Models
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            Rezervacija = new HashSet<Rezervacija>();
        }

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Email { get; set; }
        public string BrojTelefona { get; set; }

        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
    }
}
