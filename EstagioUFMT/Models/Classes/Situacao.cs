using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstagioUFMT.Models.Classes
{
    [Table("Situacao")]
    public class Situacao
    {
        [Key]
        public int codSituacao { get; set; }

        [Display(Name = "Situacao")]
        public string situacao { get; set; }

        public List<Saida> Saidas { get; set; }
    }
}