using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TurističkaAgencija.Models
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            Rezervacija = new HashSet<Rezervacija>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Morate unijeti ime")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Morate unijeti prezime")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Morate odabrati datum rođenja")]
        [DataType(DataType.Date)]
        public DateTime DatumRodjenja { get; set; }

        [EmailAddress(ErrorMessage = "Unesite važeću email adresu")]
        public string Email { get; set; }

        [RegularExpression(@"^[+][0-9]+$", ErrorMessage = "Unesite broj telefona u obliku +387 12 345 678")]
        [StringLength(17, MinimumLength = 11, ErrorMessage = "Unesite broj telefona u obliku +387 12 345 678")]
        public string BrojTelefona { get; set; }

        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
    }
}
