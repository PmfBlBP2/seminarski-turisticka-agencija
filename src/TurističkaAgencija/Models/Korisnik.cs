using System;
using System.Collections.Generic;

namespace TurističkaAgencija.Models
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            RezervacijaKorisnici = new HashSet<RezervacijaKorisnici>();
        }

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public DateTime DatumRodjenja { get; set; }

        public virtual ICollection<RezervacijaKorisnici> RezervacijaKorisnici { get; set; }
    }
}
