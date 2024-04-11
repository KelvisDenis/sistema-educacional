using Microsoft.AspNetCore.Mvc;
using SistemaEducacional.Models;
using SistemaEducacional.Models.ModelForms;
using SistemaEducacional.Services.Interfaces;
using SistemaEducacional.Services.Session;

namespace SistemaEducacional.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAluno _aluno;
        private readonly INota _nota;

        private readonly Isession isession;

        public AlunoController(INota nota,IAluno aluno, Isession isession)
        {
            _aluno = aluno;
            _nota = nota;
            this.isession = isession;
        }

        public async Task<IActionResult> Index()
        {
            var obj = await _aluno.ListAsync();
            return View(obj.OrderBy(d => d.Nome));
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(string? ConfSenha, AlunoModel? model)
        {
            if (!ModelState.IsValid || model.SenhaTemporaria != ConfSenha) return View(model);
            await _aluno.CreateAsync(model);
            var obj = await _aluno.ListAsync();
            return View(nameof(Index), obj);
        }
        public async Task<IActionResult> Emitir(int? id)
        {
            var alunos = await _aluno.GetIdAsync(id);
            var notas = await _nota.ListAsync(id);
            FormsView obj = new FormsView { NotasModels = notas, AlunoModel = alunos };
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> Alterar(AlunoModel? model)
        {
            await _aluno.UpdateAsync(model);
            var objs = await _aluno.ListAsync();
            return View(nameof(Index), objs);
        }
        [HttpPost("/Disciplina/Buscar")]
        public async Task<IActionResult> Buscar(string? nome)
        {
            var aluno = await _aluno.GetAsync(nome);
            return View(aluno);
        }

    }
}
