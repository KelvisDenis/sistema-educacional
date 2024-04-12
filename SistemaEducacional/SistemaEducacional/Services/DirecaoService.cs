using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using SistemaEducacional.Infraestrutura;
using SistemaEducacional.Models;
using SistemaEducacional.Services.Interfaces;

namespace SistemaEducacional.Services
{
    /// <summary>
    /// implementa a interface IDirecao
    /// usada para manipular a entidade DirecaoModel 
    /// </summary>
    public class DirecaoService: IDirecao
    {
        /// <summary>
        /// por injeção de depedência recebe a classe ModelContext
        /// </summary>
        private readonly ModelContext _context;

        /// <summary>
        /// construtor implementa ModelContext
        /// </summary>
        /// <param name="context"></param>
        public DirecaoService(ModelContext context) 
        {
            _context = context;
        }
        /// <summary>
        /// Cria a entiadade Direcao no banco de dados
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task CreateAsync(DirecaoModel model)
        {

            await _context.DirecaoModels.AddAsync(model);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// deleta a entidade informada pelo no banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// <summary>
        /// busca uma entidade DirecaoModel pelo id informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>um objeto do tipo DirecaoModel</returns>
        public async Task<DirecaoModel> GetIdAsync(int? id)
        {
            var user = await _context.DirecaoModels.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }
        /// <summary>
        /// busca uma entidade DirecaoModel pelo nome informado
        /// </summary>
        /// <param name="user"></param>
        /// <returns>um objeto do tipo DirecaoModel</returns>
        public async Task<DirecaoModel> GetAsync(string? nome)
        {
            var obj = await _context.DirecaoModels.FirstOrDefaultAsync(v => v.Nome == nome);
            return obj;
        }
        /// <summary>
        /// busca uma entidade DirecaoModel pelo email informado
        /// </summary>
        /// <param name="user"></param>
        /// <returns>um objeto do tipo DirecaoModel</returns>
        public async Task<DirecaoModel> GetLoginAsync(string? email)
        {
            var obj = await _context.DirecaoModels.FirstOrDefaultAsync(v => v.Email == email);
            return obj;
        }
        /// <summary>
        /// busca todas as entiadades do tipo DirecaoModel no banco de dados
        /// retorna uma lista do tipo DirecaoModel
        /// </summary>
        /// <returns>uma lista do tipo DirecaoModel</returns>
        public async Task<List<DirecaoModel>> ListAsync()
        {
            return await _context.DirecaoModels.ToListAsync();
        }
        /// <summary>
        /// atualiza uma entidade do tipo DirecaoModel no banco de dados
        /// </summary>
        /// <param name="model"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
                throw new Exception($"{ex.Message} fvggfdgfdgdfsgds", ex);
            }
        }

      
    }
}
