using Microsoft.AspNetCore.Mvc;
using SistemaEducacional.Services.Interfaces;
using SistemaEducacional.Services;
using SistemaEducacional.Services.Session;
using SistemaEducacional.Models;
using Microsoft.AspNetCore.Http;

namespace SistemaEducacional.Controllers
{
    /// <summary>
    /// Controller responsavel por gerenciar Docente
    /// </summary>
    public class DocenteController : Controller
    {
        
        /// <summary>
        /// Dependencias
        /// </summary>
        private readonly IDocente _docente;

        private readonly Isession _Isession;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="isession"></param>
        /// <param name="aluno"></param>
        public DocenteController(Isession isession, IDocente aluno)
        {
            _Isession = isession;
            _docente = aluno;
        }
        /// <summary>
        /// Exibe listagem de docentes
        /// </summary>
        /// <returns>Uma IActionResult Com todos os docentes</returns>
        [HttpGet("/Docente/Index")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var log = _Isession.GetSession();
                if (log == null) return RedirectToAction("Index", "Home");
                var model = await _docente.ListAsync();
                return View(model);
            }
            catch (Exception ex) { return View(nameof(Error)); }

        }
        /// <summary>
        /// Exibe uma pagina para criar docente
        /// </summary>
        /// <returns>Uma IActionResult com campos para criar funcionarios</returns>
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
        /// Cria um docente
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A view Index</returns>
        [HttpPost]
        public async Task<IActionResult> Create(DocenteModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);
                await _docente.CreateAsync(model);
                var obj = await _docente.ListAsync();
                return View(nameof(Index), obj);
            }
            catch (Exception ex) { return View(nameof(Error)); }
            
        }
        /// <summary>
        /// Exibe pagina para alterar docente
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Uma IActionResult para alterar dados do docente</returns>
        public async Task<IActionResult> Alterar(int? id)
        {
            try
            {
                var log = _Isession.GetSession();
                if (log == null) return RedirectToAction("Index", "Home");
                var obj = await _docente.GetIdAsync(id);
                return View(obj);
            }
            catch (Exception ex) { return View(nameof(Error)); }
         
        }
        /// <summary>
        /// Altera o funcionario
        /// </summary>
        /// <param name="model"></param>
        /// <param name="novaSenha"></param>
        /// <returns>A view Index</returns>
        [HttpPost]
        public async Task<IActionResult> Alterar(DocenteModel? model)
        {
            try
            {
                await _docente.UpdateAsync(model);
                var objs = await _docente.ListAsync();
                return View(nameof(Index), objs);
            }
            catch (Exception ex) { return View(nameof(Error)); }
          
        }
        /// <summary>
        /// Exibe uma pagina com docente requisitado
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>Uma IActionResult com o docente especificado</returns>
        [HttpPost("/Docente/Buscar")]
        public async Task<IActionResult> Buscar(string? nome)
        {
            try
            {
                var log = _Isession.GetSession();
                if (log == null) return RedirectToAction("Index", "Home");
                var aluno = await _docente.GetAsync(nome);
                return View(aluno);
            }
            catch (Exception ex) { return View(nameof(Error)); }
          
        }
        /// <summary>
        /// Exclui um docente
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A view Index</returns>
        public async Task<IActionResult> Excluir(int? id)
        {
            try
            {
                await _docente.DeleteAsync(id);
                var objs = await _docente.ListAsync();
                return View(nameof(Index), objs);
            }
            catch (Exception ex) { return View(nameof(Error)); }
           
        }
        /// <summary>
        /// Exibe pagina para erros
        /// </summary>
        /// <returns>Uma IActionResult com a pagina para erros</returns>
        [HttpGet("/Error/")]
        public IActionResult Error()
        {
            var log = _Isession.GetSession();
            if (log == null) return RedirectToAction("Index", "Home");
            return View();
        }
    }
}
