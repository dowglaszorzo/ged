using EstagioUFMT.Models.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstagioUFMT.Models
{
    [Table("Saida")]
    public class Saida
    {
        [Display(Name = "Codigo")]
        [Key]
        public int codCadastro { get; set; }


        
        [Display(Name = "Ano")]
        public int? ano { get; set; }


        
        [Display(Name = "Status do Aluno")]
        public string statusAluno { get;set; }

        
        [Display(Name = "Ano Status")]
        public int anoStatus { get; set; }

        public int codAluno { get; set; }
        public virtual Aluno Aluno { get; set; }
        public int codEnsino { get; set; }
        public virtual Ensino Ensino { get; set; }
        public int codEscola { get; set; }
        [Display(Name = "Serie")]
        public string serie { get; set; }
        public int? codSituacao { get; set; }
        [Display(Name = "Local")]
        public string local { get; set; }


        public virtual Escola Escola { get; set; }
        public virtual Situacao Situacao { get; set; }

    }
}