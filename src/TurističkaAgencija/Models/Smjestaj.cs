using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Morate unijeti naziv")]
        public string Naziv { get; set; }
        public string Opis { get; set; }
        [Required(ErrorMessage = "Morate unijeti adresu")]
        public string Adresa { get; set; }
        public string Slika { get; set; }

        public virtual Destinacija Destinacija { get; set; }
        public virtual ICollection<Ponuda> Ponuda { get; set; }
    }
}
