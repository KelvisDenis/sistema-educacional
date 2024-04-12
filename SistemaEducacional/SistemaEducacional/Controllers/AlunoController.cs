using Microsoft.AspNetCore.Mvc;
using SistemaEducacional.Models;
using SistemaEducacional.Models.ModelForms;
using SistemaEducacional.Services.Interfaces;
using SistemaEducacional.Services.Session;

namespace SistemaEducacional.Controllers
{
    /// <summary>
    /// controller responsavel por gerenciar os alunos
    /// </summary>
    public class AlunoController : Controller
    {
        /// <summary>
        /// dependências
        /// </summary>
        private readonly IAluno _aluno;
        private readonly IDisciplina _disciplina;
        private readonly INota _nota;

        private readonly Isession isession;

        /// <summary>
        /// cosntrutor
        /// </summary>
        /// <param name="nota"></param>
        /// <param name="disciplina"></param>
        /// <param name="aluno"></param>
        /// <param name="isession"></param>
        public AlunoController(INota nota, IDisciplina disciplina,IAluno aluno, Isession isession)
        {
            _aluno = aluno;
            _nota = nota;
            this.isession = isession;
            _disciplina = disciplina;
        }
        /// <summary>
        /// Exibe a view uma lista de alunos  
        /// </summary>
        /// <returns>uma IActionResult representando a pagina lista de aluno</returns>
        public async Task<IActionResult> Index()
        {
            var obj = await _aluno.ListAsync();
            return View(obj.OrderBy(d => d.Nome));
        }
        /// <summary>
        /// responsavel por renderizar a view create 
        /// </summary>
        /// <returns>uma IActionResult representando a pagina de criação do aluno</returns>
        public async Task<IActionResult> Create()
        {
            return View();
        }
        /// <summary>
        /// responsavel por criar um aluno 
        /// </summary>
        /// <returns>uma IActionResultao criar um aluno</returns>
        [HttpPost]
        public async Task<IActionResult> Create(AlunoModel? model)
        {
            if (!ModelState.IsValid) return View(model);
            await _aluno.CreateAsync(model);
            var obj = await _aluno.ListAsync();
            return View(nameof(Index), obj);
        }
        /// <summary>
        /// Exibe o boletim do aluno
        /// </summary>
        /// <returns>uma IActionResultao representando a pagina com o boletim do aluno</returns>
        public async Task<IActionResult> Emitir(int? id)
        {
            var alunos = await _aluno.GetIdAsync(id);
            var notas = await _nota.ListAsync(id);
            FormsView obj = new FormsView { NotasModels = notas, AlunoModel = alunos };
            obj.BoletimModels.Notas.AddRange(notas);
            obj.BoletimModels.Discplinas.AddRange(await _disciplina.ListAsync());
            return View(obj);
        }
        /// <summary>
        /// Altera os dados do aluno
        /// </summary>
        /// <returns>uma IActionResultao representando a pagina de listagem de alunos</returns>
        [HttpPost]
        public async Task<IActionResult> Alterar(AlunoModel? model)
        {
            await _aluno.UpdateAsync(model);
            var objs = await _aluno.ListAsync();
            return View(nameof(Index), objs);
        }
        /// <summary>
        /// Exibe o usuario encontrado
        /// </summary>
        /// <returns>uma IActionResultao representando o usuario requisitado</returns>
        [HttpPost("/Aluno/Buscar")]
        public async Task<IActionResult> Buscar(string? nome)
        {
            var aluno = await _aluno.GetAsync(nome);
            return View(aluno);
        }

    }
}
