using System;
using System.Collections.Generic;

namespace TurističkaAgencija.Models
{
    public partial class Rezervacija
    {
        public Rezervacija()
        {
            RezervacijaKorisnici = new HashSet<RezervacijaKorisnici>();
        }

        public int Id { get; set; }
        public int PonudaId { get; set; }
        public int? BrojOsoba { get; set; }

        public virtual Ponuda Ponuda { get; set; }
        public virtual ICollection<RezervacijaKorisnici> RezervacijaKorisnici { get; set; }
    }
}
