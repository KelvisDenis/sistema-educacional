using Microsoft.EntityFrameworkCore;
using SistemaEducacional.Infraestrutura;
using SistemaEducacional.Models;
using SistemaEducacional.Services.Interfaces;

namespace SistemaEducacional.Services
{
    public class DocenteService : IDocente
    {
        private readonly ModelContext _context;

        public DocenteService(ModelContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(DocenteModel? model)
        {
            await _context.DocenteModels.AddAsync(model);
            await _context.SaveChangesAsync();
        }

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

        public async Task<DocenteModel> GetAsync(string? nome)
        {
            return await _context.DocenteModels.FirstOrDefaultAsync(x=> x.Nome == nome);
        }

        public async Task<DocenteModel> GetIdAsync(int? id)
        {
            return await _context.DocenteModels.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<DocenteModel>> ListAsync()
        {
            return await _context.DocenteModels.ToListAsync();
        }

        public async Task UpdateAsync(DocenteModel model)
        {
            try
            {
                if (await _context.DocenteModels.AnyAsync(x => x.Id == model.Id)) throw new Exception("not found");

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
