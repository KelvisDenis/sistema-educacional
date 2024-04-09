using Microsoft.EntityFrameworkCore;
using SistemaEducacional.Infraestrutura;
using SistemaEducacional.Models;
using SistemaEducacional.Services.Interfaces;

namespace SistemaEducacional.Services
{
    public class TurmaService : ITurma
    {
        private readonly ModelContext _context;

        public TurmaService(ModelContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(TurmaModel? model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
        }

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

        public Task<TurmaModel> GetAsync(string? nome)
        {
            return _context.TurmaModels.FirstOrDefaultAsync(x=> x.NomeTurma == nome);
        }

        public async Task<TurmaModel> GetIdAsync(int? id)
        {
            return await _context.TurmaModels.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<TurmaModel>> ListAsync()
        {
            return await _context.TurmaModels.ToListAsync();
        }

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
