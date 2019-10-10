using System;
using System.Collections.Generic;

namespace TurističkaAgencija.Models
{
    public partial class Prevoz
    {
        public Prevoz()
        {
            Ponuda = new HashSet<Ponuda>();
        }

        public int Id { get; set; }
        public int KompanijaId { get; set; }
        public int TipPrevozaId { get; set; }
        public string Opis { get; set; }

        public virtual Kompanija Kompanija { get; set; }
        public virtual TipPrevoza TipPrevoza { get; set; }
        public virtual ICollection<Ponuda> Ponuda { get; set; }
    }
}
