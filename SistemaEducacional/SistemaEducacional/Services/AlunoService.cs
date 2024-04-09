using Microsoft.EntityFrameworkCore;
using SistemaEducacional.Infraestrutura;
using SistemaEducacional.Models;
using SistemaEducacional.Services.Interfaces;

namespace SistemaEducacional.Services
{
    public class AlunoService : IAluno
    {
        private readonly ModelContext _context;

        public AlunoService(ModelContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(AlunoModel model)
        {
            await _context.AlunoModels.AddAsync(model);
            await _context.SaveChangesAsync();
        }

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

        public async Task<AlunoModel> GetIdAsync(int? id)
        {
            return await _context.AlunoModels.FirstOrDefaultAsync(x=> x.Id == id);
        } 

        public async Task<ICollection<AlunoModel>> ListAsync()
        {
           return await _context.AlunoModels.ToListAsync();
        }

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

        public async Task<AlunoModel> GetAsync(string? nome)
        {
            return await _context.AlunoModels.FirstOrDefaultAsync(x => x.Nome == nome);
        }
    }
}
