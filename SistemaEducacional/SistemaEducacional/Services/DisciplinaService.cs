using Microsoft.EntityFrameworkCore;
using SistemaEducacional.Infraestrutura;
using SistemaEducacional.Models;
using SistemaEducacional.Services.Interfaces;

namespace SistemaEducacional.Services
{
    /// <summary>
    /// implementa a interface IDisciplina
    /// </summary>
    public class DisciplinaService : IDisciplina
    {
        /// <summary>
        /// por injeção de depedência recebe a classe ModelContext
        /// </summary>
        private readonly ModelContext _context;

        /// <summary>
        /// construtor implementa ModelContext
        /// </summary>
        public DisciplinaService(ModelContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Cria a entiadade DisciplinaModel no banco de dados
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public async Task CreateAsync(DisciplinaModel model)
        {
            await _context.DisciplinaModels.AddAsync(model);
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
            var user = await _context.DisciplinaModels.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) throw new Exception("Usuario não encontrado");
            try
            {
                _context.DisciplinaModels.Remove(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// busca uma entidade DisciplinaModel pelo nome informado
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>um objeto do tipo DisciplinaModel</returns>
        public Task<DisciplinaModel> GetAsync(string? nome)
        {
           return _context.DisciplinaModels.FirstOrDefaultAsync(x => x.Nome == nome);
        }

        /// <summary>
        /// busca uma entidade DisciplinaModel pelo id informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>um objeto do tipo DisciplinaModel</returns>
        public Task<DisciplinaModel> GetIdAsync(int? id)
        {
            return _context.DisciplinaModels.FirstOrDefaultAsync(x => x.Id == id);
        }
        /// <summary>
        /// busca todas as entiadades do tipo DisciplinaModel no banco de dados
        /// </summary>
        /// <returns>um objeto do tipo DisciplinaModel</returns>

        public async Task<List<DisciplinaModel>> ListAsync()
        {
            return await _context.DisciplinaModels.ToListAsync();
        }
        /// <summary>
        /// atualiza uma entidade do tipo DisciplinaModel no banco de dados
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task UpdateAsync(DisciplinaModel model)
        {
            try
            {
                if (!await _context.DisciplinaModels.AnyAsync(x => x.Id == model.Id)) throw new Exception("not found");

                _context.DisciplinaModels.Update(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
    }
}
