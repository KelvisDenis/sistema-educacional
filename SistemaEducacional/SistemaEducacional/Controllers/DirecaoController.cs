using Microsoft.AspNetCore.Mvc;
using SistemaEducacional.Models;
using SistemaEducacional.Services;
using SistemaEducacional.Services.Interfaces;
using SistemaEducacional.Services.Session;

namespace SistemaEducacional.Controllers
{
    public class DirecaoController : Controller
    {
        private readonly DirecaoService _service;

        private readonly Isession _Isession;

        public DirecaoController(DirecaoService service, Isession isession)
        {
            _service = service;
            _Isession = isession;
        }
        [HttpGet("/Index/")]
        public async Task<IActionResult> Index()
        {
            var model = await _service.ListAsync();
            return View(model);
        }

        public async Task<IActionResult> Alterar(int? id)
        {
            var obj = await _service.GetIdAsync(id);
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> Alterar(DirecaoModel? model, string? novaSenha)
        {
            await _service.UpdateAsync(model, novaSenha);
            var objs = await _service.ListAsync();
            return View(nameof(Index),objs );
        }
        [HttpPost("/Direção/")]
        public async Task<IActionResult> Buscar(string? nome)
        {
            var aluno = await _service.GetAsync(nome);
            return View(aluno);
        }
        public async Task<IActionResult> Excluir(int? id)
        {
            await _service.DeleteAsync(id);
            var objs = await _service.ListAsync();
            return View(nameof(Index), objs);
        }
    }
}
