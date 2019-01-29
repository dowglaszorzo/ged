using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstagioUFMT.Models
{
    [Table ("Ensino")]
    public class Ensino
    {
        [Key]
        public int codEnsino { get; set; }
        [Required(ErrorMessage = "O Ensino do aluno é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Ensino")]
        public string tipo_de_ensino { get; set; }

        public List<Saida> Saidas { get; set; }

    }
}