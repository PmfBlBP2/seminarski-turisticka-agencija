using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TurističkaAgencija.Models
{
    public partial class Drzava
    {
        public Drzava()
        {
            Destinacija = new HashSet<Destinacija>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Morate unijeti naziv")]
        public string Naziv { get; set; }

        public virtual ICollection<Destinacija> Destinacija { get; set; }
    }
}
