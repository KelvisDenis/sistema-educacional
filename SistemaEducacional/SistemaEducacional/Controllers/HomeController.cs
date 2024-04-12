using Microsoft.AspNetCore.Mvc;
using SistemaEducacional.Models;
using SistemaEducacional.Services.Interfaces;
using SistemaEducacional.Services.Session;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaEducacional.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDirecao _direcao;
        private readonly Isession _Isession;

        public HomeController(IDirecao logger, Isession isession)
        {
            _direcao = logger;
            _Isession = isession;
        }
        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/Login/")]
        public async Task<IActionResult> Login(string usuario, string senha)
        {
            if (usuario == null || senha == null) return View(nameof(Index));

           var user = await _direcao.GetLoginAsync(usuario);
            if (user == null) return View(nameof(Index));
            _Isession.CreateSession(user);
            return View(nameof(Home));
        }

        [HttpGet("/Home/")]
        public IActionResult Home()
        {
            if(_Isession.GetSession() == null) return View(nameof(Index));
            return View();
        }

        public IActionResult Alterar()
        {
            var user = _Isession.GetSession();
            if (user == null) return View(nameof(Home));
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Alterar(DirecaoModel? model, string? senhaAntiga,
            string? confirmarSenha, string? novaSenha )
        {
            if (model == null || novaSenha == null || confirmarSenha == null
                || senhaAntiga == null) return View();
            model.Senha = novaSenha;
            await _direcao.UpdateAsync(model, senhaAntiga);
            return View(nameof(Home));
        }

        [HttpGet("/exit/")]
        public IActionResult Exit()
        {
            _Isession.RemoveSession();
            return View(nameof(Index));
        }
        [Route("/Home/Error")]
        public IActionResult HandleError()
        {
            ViewBag.error = "Erro!";
            return View(nameof(Error));
        }
        public IActionResult Error()
        {
            ViewBag.error = "Erro!";
            return View(nameof(Error));
        }

    }
}
