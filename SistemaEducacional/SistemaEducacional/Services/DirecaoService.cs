using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using SistemaEducacional.Infraestrutura;
using SistemaEducacional.Models;
using SistemaEducacional.Services.Interfaces;

namespace SistemaEducacional.Services
{
    public class DirecaoService: IDirecao
    {
        private readonly ModelContext _context;
        public DirecaoService(ModelContext context) 
        {
            _context = context;
        }
        public async Task CreateAsync(DirecaoModel model)
        {

            await _context.DirecaoModels.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int? id)
        {
           var user = await  _context.DirecaoModels.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) throw new Exception("Usuario não encontrado");
            try
            {
                _context.DirecaoModels.Remove(user);
              await _context.SaveChangesAsync();
            }catch(Exception ex) 
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<DirecaoModel> GetIdAsync(int? id)
        {
            var user = await _context.DirecaoModels.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }
        public async Task<DirecaoModel> GetAsync(string? user)
        {
            var obj = await _context.DirecaoModels.FirstOrDefaultAsync(v => v.Nome == user);
            return obj;
        }
        public async Task<DirecaoModel> GetLoginAsync(string? user)
        {
            var obj = await _context.DirecaoModels.FirstOrDefaultAsync(v => v.Email == user);
            return obj;
        }
        public async Task<List<DirecaoModel>> ListAsync()
        {
            return await _context.DirecaoModels.ToListAsync();
        }

        public async Task UpdateAsync(DirecaoModel? model, string? senha)
        {   
            try
            {
                if(!await _context.DirecaoModels.AnyAsync(x=> x.Id == model.Id)) throw new Exception("Error!");
                var user = await _context.DirecaoModels.FirstOrDefaultAsync(x => x.Id == model.Id);
                model.Senha = senha == null ? user.Senha : senha;
                if (!user.CheckSenha(model.Senha)) throw new Exception("Error!");
                user.Cpf = model.Cpf;
                user.Senha = model.Senha;
                user.DataNascimento = model.DataNascimento;
                user.Nome = model.Nome;
                user.Email = model.Email;
                _context.DirecaoModels.Update(user);
               _context.SaveChanges();
            }catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }

      
    }
}
