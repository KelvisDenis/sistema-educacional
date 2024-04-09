using Microsoft.AspNetCore.Mvc;
using SistemaEducacional.Services.Interfaces;
using SistemaEducacional.Services;
using SistemaEducacional.Services.Session;
using SistemaEducacional.Models;

namespace SistemaEducacional.Controllers
{
    public class DocenteController : Controller
    {
        
        private readonly IDocente _docente;

        private readonly Isession _Isession;

        public DocenteController(Isession isession, IDocente aluno)
        {
            _Isession = isession;
            _docente = aluno;
        }
        [HttpGet("/Docente/Index")]
        public async Task<IActionResult> Index()
        {
            var model = await _docente.ListAsync();
            return View(model);
        }

        public async Task<IActionResult> Alterar(int? id)
        {
            var obj = await _docente.GetIdAsync(id);
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> Alterar(DocenteModel? model, string? novaSenha)
        {
            await _docente.UpdateAsync(model);
            var objs = await _docente.ListAsync();
            return View(nameof(Index), objs);
        }
        [HttpPost("/Docente/Buscar")]
        public async Task<IActionResult> Buscar(string? nome)
        {
            var aluno = await _docente.GetAsync(nome);
            return View(aluno);
        }
        public async Task<IActionResult> Excluir(int? id)
        {
            await _docente.DeleteAsync(id);
            var objs = await _docente.ListAsync();
            return View(nameof(Index), objs);
        }
    }
}
