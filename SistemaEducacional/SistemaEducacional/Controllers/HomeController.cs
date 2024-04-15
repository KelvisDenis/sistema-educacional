using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEducacional.Models;
using SistemaEducacional.Services.Interfaces;
using SistemaEducacional.Services.Session;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaEducacional.Controllers
{
    /// <summary>
    /// Controller reponsavel por gerenciar home do usuario
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Dependecias
        /// </summary>
        private readonly IDirecao _direcao;
        private readonly Isession _Isession;
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="isession"></param>
        public HomeController(IDirecao logger, Isession isession)
        {
            _direcao = logger;
            _Isession = isession;
        }
        /// <summary>
        /// Exibe a pagina Login
        /// </summary>
        /// <returns>Uma IActionResult para usuario efetuar login</returns>
        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Verifica se o usuario está cadastrado
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="senha"></param>
        /// <returns>View Home</returns>
        public async Task<IActionResult> Create()
        {
           
             return View();
        }
        /// <summary>
        /// Cria um diretor 
        /// </summary>
        /// <param name="ConfSenha"></param>
        /// <param name="model"></param>
        /// <returns>Uma IActionResult com os diretores</returns>
        [HttpPost]
        public async Task<IActionResult> Create(DirecaoModel? model)
        {
            try
            {
                if (!ModelState.IsValid|| _direcao.GetLoginAsync(model.Email) != null) return View(model);
                await _direcao.CreateAsync(model);
                var obj = await _direcao.ListAsync();
                 _Isession.CreateSession(model);
                return RedirectToAction(nameof(Home));
            }
            catch (Exception ex) { return View(nameof(Error)); }

        }
        [HttpPost("/Login/")]
        public async Task<IActionResult> Login(string usuario, string senha)
        {
            try
            {
                if (usuario == null || senha == null) return View(nameof(Index));

                var user = await _direcao.GetLoginAsync(usuario);
                if (user == null) return View(nameof(Index));
                _Isession.CreateSession(user);
                return View(nameof(Home));
            }
            catch (Exception ex) { return View(nameof(Error)); }
            
        }
        /// <summary>
        /// Exibe pagina com todas as funcionalidades do usuario
        /// </summary>
        /// <returns>Uma IActionResult com as funcionalidades </returns>
        [HttpGet("/Home/")]
        public IActionResult Home()
        {
            try
            {
                if (_Isession.GetSession() == null) return View(nameof(Index));
                return View();
            }
            catch (Exception ex) { return View(nameof(Error)); }
          
        }
        /// <summary>
        /// Exibe pagina para alterar os dados do usuario
        /// </summary>
        /// <returns>Uma IActionResult para o usuario alterar os seus dados</returns>
        public IActionResult Alterar()
        {
            try
            {
                var user = _Isession.GetSession();
                if (user == null) return View(nameof(Home));
                return View(user);
            }
            catch (Exception ex) { return View(nameof(Error)); }
           
        }
        /// <summary>
        /// altera os dados do usuario
        /// </summary>
        /// <param name="model"></param>
        /// <param name="senhaAntiga"></param>
        /// <param name="confirmarSenha"></param>
        /// <param name="novaSenha"></param>
        /// <returns>View Home</returns>
        [HttpPost]
        public async Task<IActionResult> Alterar(DirecaoModel? model, string? senhaAntiga,
            string? confirmarSenha, string? novaSenha )
        {
            try
            {
                if (model == null || novaSenha == null || confirmarSenha == null
               || senhaAntiga == null) return View();
                model.Senha = novaSenha;
                await _direcao.UpdateAsync(model, senhaAntiga);
                return View(nameof(Home));
            }
            catch (Exception ex) { return View(nameof(Error)); }
           
        }
        /// <summary>
        /// desloga o usuario 
        /// </summary>
        /// <returns>View Index</returns>
        [HttpGet("/exit/")]
        public IActionResult Exit()
        {
            try
            {
                _Isession.RemoveSession();
                var user = _Isession.GetSession();
                return View(nameof(Index));
            }
            catch (Exception ex) { return View(nameof(Error)); }
           
        }
       /// <summary>
       /// Exibe pagina de erro
       /// </summary>
       /// <returns></returns>
        public IActionResult Error()
        {
            ViewBag.error = "Erro!";
            return View(nameof(Error));
        }

    }
}
