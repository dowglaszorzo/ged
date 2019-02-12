using EstagioUFMT.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EstagioUFMT.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Aluno> Alunos{ get; set; }
        public DbSet<Ensino> Ensinos{ get; set; }
        public DbSet<Escola> Escolas { get; set; }
        public DbSet<Saida> Saidas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Situacao> Situacao { get; set; }
    }
}