using System;
using System.Collections.Generic;

namespace TurističkaAgencija.Models
{
    public partial class RezervacijaKorisnici
    {
        public int RezervacijaId { get; set; }
        public int KorisnikId { get; set; }
        public DateTime? DatumRezervacije { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual Rezervacija Rezervacija { get; set; }
    }
}
