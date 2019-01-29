using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstagioUFMT.Models
{

    [Table("Escola")]
    public class Escola
    {
        [Key]
        public int codEscola { get; set; }

        
        [Display(Name = "Escola")]
        public string nome { get; set; }
        public string municipio{ get; set; }

        public List<Usuario> Usuarios { get; set; }
        public List<Saida> Saidas { get; set; }

    }
}