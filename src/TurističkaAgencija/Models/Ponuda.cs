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
        [Required(ErrorMessage = "Odaberite smjestaj")]
        public int SmjestajId { get; set; }
        [Required(ErrorMessage = "Odaberite destinaciju")]
        public int DestinacijaId { get; set; }
        [Required(ErrorMessage = "Odaberite prevoz")]
        public int PrevozId { get; set; }
        [Required(ErrorMessage = "Unesite naziv ponude")]
        public string Naziv { get; set; }
        public DateTime DatumKreiranja { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Unesite datum polazka")]
        public DateTime Pocetak { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Unesite datum povratka")]
        public DateTime Kraj { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.0}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Unesite cijenu")]
        [RegularExpression("^[0-9]+([.][0-9]{1,2})?$", ErrorMessage = "Cijena je decimalni ili cio broj")]
        public decimal Cijena { get; set; }

        public virtual Destinacija Destinacija { get; set; }
        public virtual Prevoz Prevoz { get; set; }
        public virtual Smjestaj Smjestaj { get; set; }
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
    }
}
