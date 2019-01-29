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



        
        
        
        public List<Saida> Saidas { get; set; }

    }

   
}