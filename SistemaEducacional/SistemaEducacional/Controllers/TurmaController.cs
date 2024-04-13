using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEducacional.Models;
using SistemaEducacional.Models.ModelForms;
using SistemaEducacional.Services.Interfaces;
using SistemaEducacional.Services.Session;

namespace SistemaEducacional.Controllers
{
    /// <summary>
    /// Controller responsavel por gerenciar a turma
    /// </summary>
    public class TurmaController : Controller
    {
        /// <summary>
        /// Dependencias
        /// </summary>
        private readonly ITurma _turma;
        private readonly IAluno _aluno;
        private readonly IDocente _docente;
        private readonly IDisciplina _disciplina;
        private readonly Isession _session;
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="disciplina"></param>
        /// <param name="turma"></param>
        /// <param name="session"></param>
        /// <param name="aluno"></param>
        public TurmaController(IDisciplina disciplina ,
            ITurma turma, Isession session, IAluno aluno, IDocente docente)
        {
            _turma = turma;
            _session = session;
            _disciplina = disciplina;
            _aluno = aluno;
            _docente = docente;
        }
        /// <summary>
        /// Exibe a pagina com todas as turmas
        /// </summary>
        /// <returns>Uma IActionResult com a listagem de todaas as turmas </returns>
        [HttpGet("/Turma/Index")]
        public async Task<IActionResult> Index()
        {
            var model = await _turma.ListAsync();

            return View(model.OrderBy(x => x.Id));
        }


        public async Task<IActionResult> Create()
        {
            var log = _session.GetSession();
            if (log == null) return RedirectToAction("Index", "Home");
            var disciplina = await _disciplina.ListAsync();
            var docentes = await _docente.ListAsync();
            FormsView forms = new FormsView {DisciplinaModel = disciplina.ToList(), DocenteModel = docentes.ToList() };
            return View(forms);
        }
        /// <summary>
        /// Exibe uma pagina para alteração da turma
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Uma IActionResult com os dados a serem alterados</returns>
        public async Task<IActionResult> Alterar(int? id)
        {
            var turma = await _turma.GetIdAsync(id);
            var disciplina = await _disciplina.ListAsync() as List<DisciplinaModel>;
            var aluno = await _aluno.GetIdAsync(id);
            FormsView forms = new FormsView { TurmaModel = turma, DisciplinaModel = disciplina.ToList(), AlunoModel = aluno };
            return View(forms);
        }
        /// <summary>
        /// Altera os dados da turma 
        /// </summary>
        /// <param name="model"></param>
        /// <returns>View Index</returns>
        [HttpPost]
        public async Task<IActionResult> Alterar(FormsView? model)
        {
            await _turma.UpdateAsync(model.TurmaModel);
            var objs = await _turma.ListAsync();
            return View(nameof(Index), objs);
        }
        /// <summary>
        /// Exibe uma pagina com a turma especificada
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>Uma IActionResult com a turma especificada</returns>
        [HttpPost("/Turma/Buscar")]
        public async Task<IActionResult> Buscar(string? nome)
        {
            var aluno = await _turma.GetAsync(nome);
            return View(aluno);
        }
        /// <summary>
        /// Exclui turma do sistema
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View Index</returns>
        public async Task<IActionResult> Excluir(int? id)
        {
            await _turma.DeleteAsync(id);
            var objs = await _turma.ListAsync();
            return View(nameof(Index), objs);
        }
      
        /// <summary>
        /// Exibe pagina para erros
        /// </summary>
        /// <returns>Uma IActionResult com a pagina para erros</returns>
        [HttpGet("/Error/")]
        public IActionResult Error()
        {
            var log = _session.GetSession();
            if (log == null) return RedirectToAction("Index", "Home");
            return View();
        }
    }
}
