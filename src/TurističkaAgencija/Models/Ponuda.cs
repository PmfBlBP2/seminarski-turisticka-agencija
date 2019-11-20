using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Morate unijeti naziv")]
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Slika { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Morate odabrati datum kreiranja")]
        public DateTime DatumKreiranja { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Morate odabrati početak putovanja")]
        public DateTime Pocetak { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Morate odabrati kraj putovanja")]
        public DateTime Kraj { get; set; }

        [RegularExpression(@"^[0-9]+([.][0-9]{1,2})?$", ErrorMessage = "Unesite cijenu u obliku 123.45")]
        [Required(ErrorMessage = "Morate unijeti cijenu ponude")]
        public decimal Cijena { get; set; }

        [RegularExpression(@"^[0-9]+", ErrorMessage = "Unesite cio broj")]
        [Required(ErrorMessage = "Morate unijeti broj mijesta")]
        public int BrojMijesta { get; set; }

        public virtual Destinacija Destinacija { get; set; }
        public virtual Prevoz Prevoz { get; set; }
        public virtual Smjestaj Smjestaj { get; set; }
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
    }
}
