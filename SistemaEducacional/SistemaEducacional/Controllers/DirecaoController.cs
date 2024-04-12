using Microsoft.AspNetCore.Mvc;
using SistemaEducacional.Models;
using SistemaEducacional.Services;
using SistemaEducacional.Services.Interfaces;
using SistemaEducacional.Services.Session;

namespace SistemaEducacional.Controllers
{
    public class DirecaoController : Controller
    {
        private readonly IDirecao _service;

        private readonly Isession _Isession;

        public DirecaoController(IDirecao service, Isession isession)
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
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(string? ConfSenha, DirecaoModel? model)
        {
            if(!ModelState.IsValid || model.Senha != ConfSenha) return View(model);
            await _service.CreateAsync(model);
            var obj = await _service.ListAsync();
            return View(nameof(Index), obj);
        }
        public async Task<IActionResult> Alterar(int? id)
        {
            
            var obj = await _service.GetIdAsync(id);
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> Alterar(DirecaoModel model, string? novaSenha)
        {
            if (!ModelState.IsValid || model.DataNascimento == null ||
                model.Cpf == null || model.Email == null || model.Nome == null
                || novaSenha == null) return View(model);
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
