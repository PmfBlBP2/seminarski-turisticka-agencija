using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TurističkaAgencija.Models
{
    public class Pretraga
    {
        public string Destinacija { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DatumOd { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DatumDo { get; set; }

        [RegularExpression(@"^[0-9]+([.][0-9]{1,2})?$", ErrorMessage = "Unesite cijenu u obliku 123.45")]
        public decimal? CijenaOd { get; set; }

        [RegularExpression(@"^[0-9]+([.][0-9]{1,2})?$", ErrorMessage = "Unesite cijenu u obliku 123.45")]
        public decimal? CijenaDo { get; set; }
    }
}
