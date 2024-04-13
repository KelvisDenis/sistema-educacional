using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEducacional.Models;
using SistemaEducacional.Services.Interfaces;
using SistemaEducacional.Services.Session;

namespace SistemaEducacional.Controllers
{
    /// <summary>
    /// Controller responsavel por gerenciar as Disciplinas
    /// </summary>
    public class DisciplinaController : Controller
    {
        /// <summary>
        /// Dependencias
        /// </summary>
        private readonly IDisciplina _disciplina;
        private readonly Isession _session;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="direcao"></param>
        /// <param name="session"></param>
        public DisciplinaController(IDisciplina direcao, Isession session)
        {
            _disciplina = direcao;
            _session = session;
        }
        /// <summary>
        /// Exibe uma listagem de disciplinas
        /// </summary>
        /// <returns>uma IActionResult com todas as disciplinas </returns>
        [HttpGet("/Disciplina/Index")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var log = _session.GetSession();
                if (log == null) return RedirectToAction("Index", "Home");
                var model = await _disciplina.ListAsync();
                return View(model);
            }
            catch (Exception ex) { return View(nameof(Error)); }
          
        }

        /// <summary>
        /// Exibibe pagina de criação de disciplina
        /// </summary>
        /// <returns>Uma IActionResult para criar a disciplina </returns>
        public async Task<IActionResult> Create()
        {
            try
            {
                var log = _session.GetSession();
                if (log == null) return RedirectToAction("Index", "Home");
                return View();
            }
            catch (Exception ex) { return View(nameof(Error)); }
          
        }
        /// <summary>
        /// Cria uma disciplina
        /// </summary>
        /// <param name="model"></param>
        /// <returns>View Index</returns>
        [HttpPost]
        public async Task<IActionResult> Create(DisciplinaModel? model)
        {
            try
            {
                /// verifica se os campos do formulario são nulos
                if (model.DataCriacao == null || model.Nome == null) throw new Exception("Campos nulos");
                /// verifica se a idade é valida
                if (!model.CheckDate(model.DataCriacao)) throw new Exception("Data Invalida");
                /// verifica se o aluno já existe
                var disciplina = await _disciplina.GetAsync(model.Nome);
                var teste = disciplina != null ? true : false;
                if (teste) teste = disciplina.Nome == model.Nome ? throw new Exception("Aluno já cadastrado") : true;
                if (!ModelState.IsValid) return View(model);
                await _disciplina.CreateAsync(model);
                var obj = await _disciplina.ListAsync();
                return View(nameof(Index), obj);
            }
            catch (Exception ex) { ViewBag.erro = ex.Message; return View(nameof(Create), model); }
        }
        /// <summary>
        /// Exibe uma pagina para alterar a disciplina
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Uma IActionResult com os dados para serem alterados</returns>
        public async Task<IActionResult> Alterar(int? id)
        {
            try
            {
                var log = _session.GetSession();
                if (log == null) return RedirectToAction("Index", "Home");

                var obj = await _disciplina.GetIdAsync(id);
                return View(obj);
            }
            catch (Exception ex) { return View(nameof(Error)); }
           
        }
        /// <summary>
        /// Altera os dados 
        /// </summary>
        /// <param name="model"></param>
        /// <returns>View Index</returns>
        [HttpPost]
        public async Task<IActionResult> Alterar(DisciplinaModel? model)
        {
            try
            {
                await _disciplina.UpdateAsync(model);
                var objs = await _disciplina.ListAsync();
                return View(nameof(Index), objs);
            }
            catch (Exception ex) { return View(nameof(Error)); }
            
        }
        /// <summary>
        /// Exibe uma pagina com o item requerido
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>Uma IActionResult com o item especificado</returns>
        [HttpPost("/Disciplina/Buscar")]
        public async Task<IActionResult> Buscar(string? nome)
        {
            try
            {
                var aluno = await _disciplina.GetAsync(nome);
                return View(nameof(Buscar), aluno);
            }
            catch (Exception ex) { return View(nameof(Error)); }

        }

        /// <summary>
        /// Exclui o item especificado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View Index</returns>
        public async Task<IActionResult> Excluir(int? id)
        {
            try
            {
                await _disciplina.DeleteAsync(id);
                var objs = await _disciplina.ListAsync();
                return View(nameof(Index), objs);
            }catch (Exception ex) { return View(nameof(Error)); }
           
        }
        /// <summary>
        /// Exibe pagina para erros
        /// </summary>
        /// <returns>Uma IActionResult com a pagina para erros</returns>
        [HttpGet("/Error/")]
        public IActionResult Error()
        {
            var log = _session.GetSession();
            if (log == null) return RedirectToAction("Index", "Home");
            return View();
        }
    }
}
