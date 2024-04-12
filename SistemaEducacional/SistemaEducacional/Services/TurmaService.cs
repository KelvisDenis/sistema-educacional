using Microsoft.EntityFrameworkCore;
using SistemaEducacional.Infraestrutura;
using SistemaEducacional.Models;
using SistemaEducacional.Services.Interfaces;

namespace SistemaEducacional.Services
{
    /// <summary>
    /// implementa a interface ITurma
    /// </summary>
    public class TurmaService : ITurma
    {
        /// <summary>
        /// por injeção de depedência recebe a classe ModelContext
        /// </summary>
        private readonly ModelContext _context;
        /// <summary>
        /// construtor implementa ModelContext
        /// </summary>
        public TurmaService(ModelContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Cria a entiadade TurmaModel no banco de dados
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public async Task CreateAsync(TurmaModel? model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// deleta a entidade informada pelo id no banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task DeleteAsync(int? id)
        {
            var user = await _context.TurmaModels.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) throw new Exception("Usuario não encontrado");
            try
            {
                _context.TurmaModels.Remove(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// busca uma entidade TurmaModel pelo nome informado
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>um objeto do tipo TurmaModel</returns>
        public Task<TurmaModel> GetAsync(string? nome)
        {
            return _context.TurmaModels.FirstOrDefaultAsync(x=> x.NomeTurma == nome);
        }

        /// <summary>
        /// busca uma entidade TurmaModel pelo id informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>um objeto do tipo TurmaModel</returns>
        public async Task<TurmaModel> GetIdAsync(int? id)
        {
            var turma = await _context.TurmaModels.FirstOrDefaultAsync(x => x.Id == id);
            turma.Docentes = await _context.DocenteModels.ToListAsync();
            turma.Alunos = await _context.AlunoModels.ToListAsync();
            return turma;
        }
        /// <summary>
        /// busca todas as entiadades do tipo TurmaModel no banco de dados
        /// </summary>
        /// <returns>um objeto do tipo TurmaModel</returns>
        public async Task<ICollection<TurmaModel>> ListAsync()
        {
            return await _context.TurmaModels.ToListAsync();
        }
        /// <summary>
        /// atualiza uma entidade do tipo TurmaModel no banco de dados
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task UpdateAsync(TurmaModel? model)
        {
            try
            {
                if (await _context.TurmaModels.AnyAsync(x => x.Id == model.Id)) throw new Exception("not found");

                _context.TurmaModels.Update(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
    }
}
