using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstagioUFMT.Models
{
    public class PesquisaViewModel
    {
        public string sortOrder { get; set; }
        
       
        public int ? page { get; set; }
        
         
        public int ? pesquisarCod { get; set; }
        public string pesquisarNome { get; set; }
        public int ? pesquisarano { get; set; }
        public int? pesquisarano2 { get; set; }
        public string pesquisarEnsino { get; set; }

        public PagedList.IPagedList<EstagioUFMT.Models.Saida> lista { get; set; }
   




    }
}