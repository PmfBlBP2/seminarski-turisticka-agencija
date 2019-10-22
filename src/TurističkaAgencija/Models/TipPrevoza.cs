using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TurističkaAgencija.Models
{
    public partial class TipPrevoza
    {
        public TipPrevoza()
        {
            Prevoz = new HashSet<Prevoz>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Morate unijeti naziv")]
        public string Naziv { get; set; }

        public virtual ICollection<Prevoz> Prevoz { get; set; }
    }
}
