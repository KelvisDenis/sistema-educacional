using Microsoft.AspNetCore.Mvc;
using SistemaEducacional.Models;
using SistemaEducacional.Models.ModelForms;
using SistemaEducacional.Services.Interfaces;
using SistemaEducacional.Services.Session;

namespace SistemaEducacional.Controllers
{
    public class TurmaController : Controller
    {
        private readonly ITurma _turma;
        private readonly IAluno _aluno;
        private readonly IDisciplina _disciplina;
        private readonly Isession _session;

        public TurmaController(IDisciplina disciplina ,ITurma turma, Isession session, IAluno aluno)
        {
            _turma = turma;
            _session = session;
            _disciplina = disciplina;
            _aluno = aluno;
        }

        [HttpGet("/Turma/Index")]
        public async Task<IActionResult> Index()
        {
            var model = await _turma.ListAsync();

            return View(model.OrderBy(x => x.Id));
        }

        public async Task<IActionResult> Alterar(int? id)
        {
            var turma = await _turma.GetIdAsync(id);
            var disciplina = await _disciplina.ListAsync() as List<DisciplinaModel>;
            var aluno = await _aluno.GetIdAsync(id);
            FormsView forms = new FormsView { TurmaModel = turma, DisciplinaModel = disciplina.ToList(), AlunoModel = aluno };
            return View(forms);
        }
        [HttpPost]
        public async Task<IActionResult> Alterar(FormsView? model)
        {
            await _turma.UpdateAsync(model.TurmaModel);
            var objs = await _turma.ListAsync();
            return View(nameof(Index), objs);
        }
        [HttpPost("/Turma/Buscar")]
        public async Task<IActionResult> Buscar(string? nome)
        {
            var aluno = await _turma.GetAsync(nome);
            return View(aluno);
        }
        public async Task<IActionResult> Excluir(int? id)
        {
            await _turma.DeleteAsync(id);
            var objs = await _turma.ListAsync();
            return View(nameof(Index), objs);
        }
    }
}
