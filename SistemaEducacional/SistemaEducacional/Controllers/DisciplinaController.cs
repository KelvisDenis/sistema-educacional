using Microsoft.AspNetCore.Mvc;
using SistemaEducacional.Models;
using SistemaEducacional.Services.Interfaces;
using SistemaEducacional.Services.Session;

namespace SistemaEducacional.Controllers
{
    public class DisciplinaController : Controller
    {
        private readonly IDisciplina _disciplina;
        private readonly Isession _session;

        public DisciplinaController(IDisciplina direcao, Isession session)
        {
            _disciplina = direcao;
            _session = session;
        }

        [HttpGet("/Disciplina/Index")]
        public async Task<IActionResult> Index()
        {
            var model = await _disciplina.ListAsync();
            return View(model);
        }

        public async Task<IActionResult> Alterar(int? id)
        {
            var obj = await _disciplina.GetIdAsync(id);
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> Alterar(DisciplinaModel? model)
        {
            await _disciplina.UpdateAsync(model);
            var objs = await _disciplina.ListAsync();
            return View(nameof(Index), objs);
        }
        [HttpPost("/Disciplina/Buscar")]
        public async Task<IActionResult> Buscar(string? nome)
        {
            var aluno = await _disciplina.GetAsync(nome);
            return View(aluno);
        }
        public async Task<IActionResult> Excluir(int? id)
        {
            await _disciplina.DeleteAsync(id);
            var objs = await _disciplina.ListAsync();
            return View(nameof(Index), objs);
        }
    }
}
