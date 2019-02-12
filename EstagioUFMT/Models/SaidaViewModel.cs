using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EstagioUFMT.Models
{
    public class SaidaViewModel
    {

        public int codAluno { get; set; }

        [Required(ErrorMessage = "O Nome do aluno é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Ensino do aluno é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Ensino")]
        public int codEnsino { get; set; }

       

        [Required(ErrorMessage = "O Ano do aluno é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Ano")]
        public int? ano { get; set; }

        [Display(Name = "Nome da Mãe")]
        public string NomeMae { get; set; }

        [Display(Name = "Data de Nascimento")]
        public string dataNasc { get; set; }

        [Display(Name = "Local")]
        public string local { get; set; }

        [Display(Name = "Série")]
        public string serie { get; set; }

        [Display(Name = "Situação")]
        public string codSituacao { get; set; }

        public int codEscola { get; set; }
        public string statusAluno { get; set; }
        public int anoStatus { get; set; }

        

        


    }

    
}