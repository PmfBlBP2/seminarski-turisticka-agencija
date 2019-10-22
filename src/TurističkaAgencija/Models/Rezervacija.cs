using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TurističkaAgencija.Models
{
    public partial class Rezervacija
    {
        public int PonudaId { get; set; }
        public int KorisnikId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DatumRezervacije { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Iznos { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual Ponuda Ponuda { get; set; }
    }
}
