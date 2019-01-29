using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstagioUFMT.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int codUsuario { get; set; }
        public int cpf { get; set; }
        public string nome { get; set; }

        public int codEscola { get; set; }
       
        public virtual Escola Escola { get; set; }

        
    }
}