using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEducacional.Models;
using SistemaEducacional.Models.ModelForms;
using SistemaEducacional.Services.Interfaces;
using SistemaEducacional.Services.Session;

namespace SistemaEducacional.Controllers
{
    /// <summary>
    /// controller responsavel por gerenciar os alunos
    /// </summary>
    public class AlunoController : Controller
    {
        /// <summary>
        /// dependências
        /// </summary>
        private readonly IAluno _aluno;
        private readonly IDisciplina _disciplina;
        private readonly INota _nota;

        private readonly Isession isession;

        /// <summary>
        /// cosntrutor
        /// </summary>
        /// <param name="nota"></param>
        /// <param name="disciplina"></param>
        /// <param name="aluno"></param>
        /// <param name="isession"></param>
        public AlunoController(INota nota, IDisciplina disciplina,IAluno aluno, Isession isession)
        {
            _aluno = aluno;
            _nota = nota;
            this.isession = isession;
            _disciplina = disciplina;
        }
        /// <summary>
        /// Exibe a view com uma lista de alunos  
        /// </summary>
        /// <returns>uma IActionResult representando a pagina lista de aluno</returns>
        [HttpGet("/Aluno/Index/")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var log = isession.GetSession();
                if (log == null) return RedirectToAction("Index", "Home");
                var obj = await _aluno.ListAsync();
                return View(obj.OrderBy(d => d.Nome));
            }
            catch (Exception ex) { return View(nameof(Error)); }

        }
        /// <summary>
        /// responsavel por renderizar a view create 
        /// </summary>
        /// <returns>uma IActionResult representando a pagina de criação do aluno</returns>
        [HttpGet("/Aluno/Create/")]
        public IActionResult Create()
        {
            try
            {
                var log = isession.GetSession();
                if (log == null) return RedirectToAction("Index", "Home");
                return View();
            }
            catch (Exception ex) { return View(nameof(Error)); }
        
        }
        /// <summary>
        /// responsavel por criar um aluno 
        /// </summary>
        /// <returns>uma IActionResultao lista de alunos</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AlunoModel? model)
        {
            var log = isession.GetSession();
            if (log == null) return RedirectToAction("Index", "Home");
            try
            {
                /// verifica se os campos do formulario são nulos
                if (model.Email == null || model.Nome == null || model.DataNascimento == null ||
                    model.Cpf == null) throw new Exception("Campos nulos");
                /// verifica se a idade é valida
                if (!model.CheckDate(model.DataNascimento)) throw new Exception("Data Invalida");
                /// verifica se o aluno já existe
                var aluno = await _aluno.GetCpfAsync(model.Cpf);
                var teste = aluno != null ? true : false;
                if(teste) teste = aluno.Cpf == model.Cpf || aluno.Email == model.Email? throw new Exception("Aluno já cadastrado"): true;
                await _aluno.CreateAsync(model);
                var obj = await _aluno.ListAsync();
                return View(nameof(Index), obj);
            }catch (Exception ex) { return View(nameof(Create), model); }
           
        }
        /// <summary>
        /// Exibe o boletim do aluno
        /// </summary>
        /// <returns>uma IActionResultao representando a pagina com o boletim do aluno</returns>
        [HttpGet("/Aluno/Emitir/")]
        public async Task<IActionResult> Emitir(int? id)
        {
            try
            {
                var log = isession.GetSession();
                if (log == null) return RedirectToAction("Index", "Home");
                var alunos = await _aluno.GetIdAsync(id);
                var notas = await _nota.ListAsync(id);
                FormsView obj = new FormsView { NotasModels = notas, AlunoModel = alunos };
                obj.BoletimModels.Notas.AddRange(notas);
                obj.BoletimModels.Discplinas.AddRange(await _disciplina.ListAsync());
                return View(obj);
            }
            catch (Exception ex) { return View(nameof(Error)); }
         
        }
        /// <summary>
        /// Exibe a view Alterar 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>uma IActionResult representando os dados do usuario a ser alterado</returns>
        [HttpGet("/Aluno/Alterar/")]
        public async Task<IActionResult> Alterar(int? id)
        {
            var log = isession.GetSession();
            if (log == null) return RedirectToAction("Index", "Home");
            try
            {
                var aluno = await _aluno.GetIdAsync(id);
                if (aluno == null) throw new Exception("Aluno não encontrado");
                return View(aluno);
            }
            catch (Exception ex) { return View(nameof(Error)); }

        }
        /// <summary>
        /// Altera os dados do aluno
        /// </summary>
        /// <returns>uma IActionResultao representando a pagina de listagem de alunos</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alterar(AlunoModel? model)
        {
            var log = isession.GetSession();
            if (log == null) return RedirectToAction("Index", "Home");
            try
            {
                if (model.Nome == null || model.Cpf == null || model.DataNascimento == null)
                    throw new Exception("Campos nulos");
                await _aluno.UpdateAsync(model);
                var objs = await _aluno.ListAsync();
                return View(nameof(Index), objs);
            }catch (Exception ex) { return View(nameof(Error)) ; }
           
        }
        /// <summary>
        /// Exibe o usuario encontrado
        /// </summary>
        /// <returns>uma IActionResultao representando o usuario requisitado</returns>
        [HttpPost("/Aluno/Buscar")]
        public async Task<IActionResult> Buscar(string? nome)
        {
            var log = isession.GetSession();
            if (log == null) return RedirectToAction("Index", "Home");
            try
            {
                var aluno = await _aluno.GetAsync(nome);
                return View(aluno);
            }
            catch (Exception ex) { return View(nameof(Error)); }
        }
        /// <summary>
        /// Exclui Aluno
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View Index</returns>
        public async Task<IActionResult> Excluir(int? id)
        {
            try
            {
                var log = isession.GetSession();
                if (log == null) return RedirectToAction("Index", "Home");

                await _aluno.DeleteAsync(id);
                var objs = await _aluno.ListAsync();
                return View(nameof(Index), objs);
            }
            catch (Exception ex) { return View(nameof(Error)); }

        }
        /// <summary>
        /// Exibe pagina erro
        /// </summary>
        /// <returns>uma IActionResult exibindo o erro</returns>
        [HttpGet("/Error/")]
        public IActionResult Error()
        {
            var log = isession.GetSession();
            if (log == null) return RedirectToAction("Index", "Home");
            return View();
        }


    }
}
