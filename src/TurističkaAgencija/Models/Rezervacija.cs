using System;
using System.Collections.Generic;

namespace TurističkaAgencija.Models
{
    public partial class Rezervacija
    {
        public int PonudaId { get; set; }
        public int KorisnikId { get; set; }
        public DateTime? DatumRezervacije { get; set; }
        public decimal? Iznos { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual Ponuda Ponuda { get; set; }
    }
}
