using Microsoft.EntityFrameworkCore;
using SistemaEducacional.Infraestrutura;
using SistemaEducacional.Models;
using SistemaEducacional.Services.Interfaces;

namespace SistemaEducacional.Services
{
    /// <summary>
    /// implementa a interface IDocente
    /// </summary>
    public class DocenteService : IDocente
    {
        /// <summary>
        /// por injeção de depedência recebe a classe ModelContext
        /// </summary>
        private readonly ModelContext _context;
        /// <summary>
        /// construtor implementa ModelContext
        /// </summary>
        public DocenteService(ModelContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Cria a entiadade DocenteModel no banco de dados
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public async Task CreateAsync(DocenteModel? model)
        {
            await _context.DocenteModels.AddAsync(model);
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
            var user = await _context.DocenteModels.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) throw new Exception("Usuario não encontrado");
            try
            {
                _context.DocenteModels.Remove(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// busca uma entidade DocenteModel pelo nome informado
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>um objeto do tipo DocenteModel</returns>
        public async Task<DocenteModel> GetAsync(string? nome)
        {
            return await _context.DocenteModels.FirstOrDefaultAsync(x=> x.Nome == nome);
        }

        /// <summary>
        /// busca uma entidade DocenteModel pelo id informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>um objeto do tipo DocenteModel</returns>
        public async Task<DocenteModel> GetIdAsync(int? id)
        {
            return await _context.DocenteModels.FirstOrDefaultAsync(x => x.Id == id);
        }
        /// <summary>
        /// busca todas as entiadades do tipo DocenteModel no banco de dados
        /// </summary>
        /// <returns>um objeto do tipo DocenteModel</returns>
        public async Task<ICollection<DocenteModel>> ListAsync()
        {
            return await _context.DocenteModels.ToListAsync();
        }

        /// <summary>
        /// atualiza uma entidade do tipo DocenteModel no banco de dados
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task UpdateAsync(DocenteModel model)
        {
            try
            {
                if (!await _context.DocenteModels.AnyAsync(x => x.Id == model.Id)) throw new Exception("not found");

                _context.DocenteModels.Update(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
    }
}
