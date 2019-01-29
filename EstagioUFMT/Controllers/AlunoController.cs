using EstagioUFMT.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
using System.Data.Entity;

namespace EstagioUFMT.Controllers
{
    public class AlunoController : Controller
    {
        DataBaseContext db;
        public AlunoController()
        {
            db = new DataBaseContext();
        }
        // GET: Saidas

        public ActionResult Index()
        {

            var cadastro = db.Saidas.ToList();
            return View(cadastro);

        }

        public ActionResult Create()
        {
            ViewBag.Ensinos = db.Ensinos;

            var model = new SaidaViewModel();
            return View(model);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaidaViewModel model)
        {
            if (ModelState.IsValid)
            {

                ///CADASTRO DE ALUNOS NO BANCO
                var cadastro2 = new Aluno();


                cadastro2.Nome = model.Nome;
                db.Alunos.Add(cadastro2);
                db.SaveChanges();



                ///CADASTRO DE SAIDAS

                var cadastro = new Saida();
                cadastro.codAluno = cadastro2.codAluno;
                cadastro.codEnsino = model.codEnsino;
                cadastro.codEscola = 1;
                cadastro.ano = model.ano;
                cadastro.statusAluno = model.statusAluno;
                cadastro.anoStatus = model.anoStatus;


                db.Saidas.Add(cadastro);
                db.SaveChanges();


                return RedirectToAction("Create");

            }
            // Se ocorrer um erro retorna para pagina
            ViewBag.Saidas = db.Saidas;
            return View(model);


        }



        //GET Aluno/Search   

        public ActionResult Search(PesquisaViewModel vm)
        {
            
            ViewBag.CodSortParm = String.IsNullOrEmpty(vm.sortOrder) ? "cod_desc" : "";
            ViewBag.NomeSortParm = String.IsNullOrEmpty(vm.sortOrder) ? "nome_desc" : "";
            ViewBag.TipoDeEnsinoSortParm = String.IsNullOrEmpty(vm.sortOrder) ? "tipoDeEnsino_desc" : "";
            ViewBag.AnoSortParm = String.IsNullOrEmpty(vm.sortOrder) ? "ano_desc" : "";
            ViewBag.NomeEscolaSortParm = String.IsNullOrEmpty(vm.sortOrder) ? "nomeEscola_desc" : "";

            

            var students = from s in db.Saidas select s;
            var tiposDeEnsinos = from a in db.Ensinos select a;

            ViewBag.Ensinos = tiposDeEnsinos.ToList();

            switch (vm.sortOrder)
            {
                case "cod_desc":
                    students = students.OrderBy(s => s.codAluno);
                    break;
                case "nome_desc":
                    students = students.OrderByDescending(s => s.Aluno.Nome);
                    break;
                case "tipoDeEnsino_desc":
                    students = students.OrderBy(s => s.Ensino.codEnsino);
                    break;
                case "ano_desc":
                    students = students.OrderBy(s => s.ano);
                    break;
                case "nomeEscola_desc":
                    students = students.OrderBy(s => s.Escola.nome);
                    break;


                default:
                    students = students.OrderBy(s => s.Aluno.Nome);
                    break;
            }

            //IF DE AREA DE PESQUISA 
            string pCod = vm.pesquisarCod.ToString();
            string ConvAno = vm.pesquisarano.ToString();
            string ConvAno2 = vm.pesquisarano2.ToString();

            if (!string.IsNullOrEmpty(pCod))
            {
                students = students.Where(s => DbFunctions.Like(s.codAluno.ToString().ToUpper(), "%" + vm.pesquisarCod.ToString().ToUpper() + "%"));

               
            }

            if (!string.IsNullOrEmpty(ConvAno))
            {
                students = students.Where(s => DbFunctions.Like(s.ano.ToString().ToUpper(), "%" + vm.pesquisarano.ToString().ToUpper() + "%"));
            }
          

            if (!string.IsNullOrEmpty(vm.pesquisarNome))
            {               
                students = students.Where(s => DbFunctions.Like(s.Aluno.Nome.ToUpper(), "%" + vm.pesquisarNome.ToUpper() + "%"));
            }

            if (!string.IsNullOrEmpty(vm.pesquisarEnsino))
            {
                students = students.Where(s => DbFunctions.Like(s.Ensino.tipo_de_ensino.ToUpper(), "%" + vm.pesquisarEnsino.ToUpper() + "%"));
            }


        
            int pageSize = 5;
            int pageNumber = (vm.page ?? 1);
            vm.lista = students.ToPagedList(pageNumber, pageSize);
            return View(vm);

           
        }





        //GET Aluno/Details

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saida saida = db.Saidas.Find(id);
            if (saida == null)
            {
                return HttpNotFound();
            }

            return View(saida);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details([Bind(Include = "codCadastro,statusAluno,anoStatus")] Saida model)
        {
            if (ModelState.IsValid)
            {
                var saida = db.Saidas.Find(model.codCadastro);
                if (saida == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                saida.statusAluno = model.statusAluno;
                saida.anoStatus = model.anoStatus;


                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }


        // GET: Aluno/Delete/
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Saida saida = db.Saidas.Find(id);
            if (saida == null)
            {
                return HttpNotFound();
            }

            return View(saida);
        }


        // Aluno/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Deletar(int id)
        {

            Saida saida = db.Saidas.Find(id);
            Aluno tbAluno = db.Alunos.Find(saida.codAluno);
            db.Saidas.Remove(saida);
            db.Alunos.Remove(tbAluno);
            db.SaveChanges();

            return RedirectToAction("Search");
        }


        //Aluno/Visualizar
        public ActionResult Show(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saida saida = db.Saidas.Find(id);
            if (saida == null)
            {
                return HttpNotFound();
            }

            return View(saida);
        }



    }
}
