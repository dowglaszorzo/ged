using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstagioUFMT.Models
{
    [Table("Aluno")]
    public class Aluno
    {
        [Key]
        public int codAluno { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Nome Mãe")]
        public string NomeMae { get; set; }
        [Display(Name = "Data de Nascimento")]
        public string dataNasc { get; set; }

        public List<Saida> Saidas { get; set; }

    }

   
}