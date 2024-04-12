using Microsoft.EntityFrameworkCore;
using SistemaEducacional.Infraestrutura;
using SistemaEducacional.Models;
using SistemaEducacional.Services.Interfaces;

namespace SistemaEducacional.Services
{
    /// <summary>
    /// classe implementa a interface Ialuno
    /// usada para manipular a entidade aluno no banco de dados
    /// </summary>
    public class AlunoService : IAluno
    {
        /// <summary>
        /// por injeção de depedência recebe a classe ModelContext
        /// </summary>
        private readonly ModelContext _context;
        /// <summary>
        /// construtor que recebe a ModelContext e introduz para ser usada
        /// </summary>
        /// <param name="context"></param>
        public AlunoService(ModelContext context)
        {
            _context = context;
        }
        /// <summary>
        /// cria um aluno no banco de dados
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task CreateAsync(AlunoModel model)
        {
            await _context.AlunoModels.AddAsync(model);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// deleta um aluno no banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task DeleteAsync(int? id)
        {

            var user = await _context.AlunoModels.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) throw new Exception("Usuario não encontrado");
            try
            {
                _context.AlunoModels.Remove(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// busca um usuario pelo id no banco de dados retorna um aluno
        /// </summary>
        /// <param name="id"></param>
        /// <returns>um objeto do tipo AlunoModel</returns>
        public async Task<AlunoModel> GetIdAsync(int? id)
        {
            return await _context.AlunoModels.FirstOrDefaultAsync(x=> x.Id == id);
        }
        /// <summary>
        /// retorna uma lista de todos os alunos do banco de dados  
        /// </summary>
        /// <returns>uma lista do tipo AlunoModel</returns>

        public async Task<ICollection<AlunoModel>> ListAsync()
        {
           return await _context.AlunoModels.ToListAsync();
        }
        /// <summary>
        /// atualiza a entidade no banco de dados
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task UpdateAsync(AlunoModel model)
        {
            var aluno = await _context.AlunoModels.FirstOrDefaultAsync(x => x.Nome == model.Nome);
            try
            {
                aluno = model;
                _context.Update(aluno);
                await _context.SaveChangesAsync();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// buca um objeto do tipo aluno por nome, no banco de dados
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>um objeto do tipo AlunoModel</returns>
        public async Task<AlunoModel> GetAsync(string? nome)
        {
            return await _context.AlunoModels.FirstOrDefaultAsync(x => x.Nome == nome);
        }
    }
}
