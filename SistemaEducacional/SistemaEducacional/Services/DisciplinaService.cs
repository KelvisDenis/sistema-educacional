using Microsoft.EntityFrameworkCore;
using SistemaEducacional.Infraestrutura;
using SistemaEducacional.Models;
using SistemaEducacional.Services.Interfaces;

namespace SistemaEducacional.Services
{
    public class DisciplinaService : IDisciplina
    {
        private readonly ModelContext _context;

        public DisciplinaService(ModelContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(DisciplinaModel model)
        {
            await _context.DisciplinaModels.AddAsync(model);
            await _context.SaveChangesAsync();
        }

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

        public Task<DisciplinaModel> GetAsync(string? nome)
        {
           return _context.DisciplinaModels.FirstOrDefaultAsync(x => x.Nome == nome);
        }
        public Task<DisciplinaModel> GetIdAsync(int? id)
        {
            return _context.DisciplinaModels.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<DisciplinaModel>> ListAsync()
        {
            return await _context.DisciplinaModels.ToListAsync();
        }

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
