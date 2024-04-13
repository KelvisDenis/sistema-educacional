using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEducacional.Models;
using SistemaEducacional.Services;
using SistemaEducacional.Services.Interfaces;
using SistemaEducacional.Services.Session;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaEducacional.Controllers
{
    /// <summary>
    /// Controller responsavel por gerenciar Direção
    /// </summary>
    public class DirecaoController : Controller
    {
        /// <summary>
        /// Dependencias
        /// </summary>
        private readonly IDirecao _service;

        private readonly Isession _Isession;
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="service"></param>
        /// <param name="isession"></param>
        public DirecaoController(IDirecao service, Isession isession)
        {
            _service = service;
            _Isession = isession;
        }
        /// <summary>
        /// Exibe uma listagem de todos od diretores
        /// </summary>
        /// <returns>Uma IActionResult com uma listagem de diretores </returns>
        [HttpGet("/Index/")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var log = _Isession.GetSession();
                if (log == null) return RedirectToAction("Index", "Home");
                var model = await _service.ListAsync();
                return View(model);
            }
            catch (Exception ex) { return View(nameof(Error)); }
           
        }
        /// <summary>
        /// Exibe uma pagina para criação de diretor
        /// </summary>
        /// <returns>Uma IActionResult com campos para criar diretor</returns>
        public async Task<IActionResult> Create()
        {
            try
            {
                var log = _Isession.GetSession();
                if (log == null) return RedirectToAction("Index", "Home");
                return View();
            }
            catch (Exception ex) { return View(nameof(Error)); }
           
        }
        /// <summary>
        /// Cria um diretor 
        /// </summary>
        /// <param name="ConfSenha"></param>
        /// <param name="model"></param>
        /// <returns>Uma IActionResult com os diretores</returns>
        [HttpPost]
        public async Task<IActionResult> Create(string? ConfSenha, DirecaoModel? model)
        {
            try
            {
                var log = _Isession.GetSession();
                if (log == null) return RedirectToAction("Index", "Home");

                if (!ModelState.IsValid || model.Senha != ConfSenha) return View(model);
                await _service.CreateAsync(model);
                var obj = await _service.ListAsync();
                return View(nameof(Index), obj);
            }
            catch (Exception ex) { return View(nameof(Error)); }
      
        }
        /// <summary>
        /// Exibe uma pagina para alterar os dados do diretor
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Uma IActionResult com os dados do diretor para modificar</returns>
        public async Task<IActionResult> Alterar(int? id)
        {
            try
            {
                var obj = await _service.GetIdAsync(id);
                return View(obj);
            }
            catch (Exception ex) { return View(nameof(Error)); }
           
        }
        /// <summary>
        /// Altera os dados do diretor
        /// </summary>
        /// <param name="model"></param>
        /// <param name="novaSenha"></param>
        /// <returns>Uma IActionResult com todos os diretores</returns>
        [HttpPost]
        public async Task<IActionResult> Alterar(DirecaoModel model, string? senhaAntiga)
        {
            try
            {
                var log = _Isession.GetSession();
                if (log == null) return RedirectToAction("Index", "Home");

                if (!ModelState.IsValid || model.DataNascimento == null ||
                    model.Cpf == null || model.Email == null || model.Nome == null) return View(model);
                await _service.UpdateAsync(model, senhaAntiga);
                var objs = await _service.ListAsync();
                return View(nameof(Index), objs);
            }
            catch (Exception ex) { return View(nameof(Error)); }
          
        }
        /// <summary>
        /// Exibe um diretor especificado
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>Uma IActionResult com o diretor especificado</returns>
        [HttpPost("/Disciplina/")]
        public async Task<IActionResult> Buscar(string? nome)
        {
            var log = _Isession.GetSession();
            if (log == null) return RedirectToAction("Index", "Home");

            try
            {
                var aluno = await _service.GetAsync(nome);
                if(aluno == null) throw new Exception("Usuario não encontrado");
                return View(aluno);
            }
            catch (Exception ex) { return View(nameof(Error)); }

        }
        /// <summary>
        /// Exclui um diretor
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Uma IActionResult com a listagem de diretores </returns>
        public async Task<IActionResult> Excluir(int? id)
        {
            try
            {
                var log = _Isession.GetSession();
                if (log == null) return RedirectToAction("Index", "Home");

                await _service.DeleteAsync(id);
                var objs = await _service.ListAsync();
                return View(nameof(Index), objs);
            }
            catch (Exception ex) { return View(nameof(Error)); }
         
        }
        /// <summary>
        /// Exibe pagina de erro
        /// </summary>
        /// <returns>Uma IActionResult Erro</returns>
        [HttpGet("/Error/")]
        public IActionResult Error()
        {
            var log = _Isession.GetSession();
            if (log == null) return RedirectToAction("Index", "Home");
            return View();
        }
    }
}
