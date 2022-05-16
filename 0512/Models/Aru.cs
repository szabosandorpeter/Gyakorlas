using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _0512.Models
{
    public class Aru
    {
        public int Id  { get; set; }

        [Display(Name ="Megnevezés")]
        [StringLength(60)]
        public string Megnevezes { get; set; }

        [Display(Name = "beszallito")]
        [StringLength(30)]
        public string Beszallito { get; set; }

        [Display(Name ="Beszerzési Ár")]
        [Column(TypeName ="decimal(10,2)")]
        public decimal Ar { get; set; }

    }
}
