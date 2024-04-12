using Microsoft.EntityFrameworkCore;
using SistemaEducacional.Infraestrutura;
using SistemaEducacional.Models;
using SistemaEducacional.Services.Interfaces;

namespace SistemaEducacional.Services
{
    /// <summary>
    /// implementa a interface INota
    /// </summary>
    public class NotaService : INota
    {
        /// <summary>
        /// por injeção de depedência recebe a classe ModelContext
        /// </summary>
        private readonly ModelContext context;

        /// <summary>
        /// construtor implementa ModelContext
        /// </summary>
        public NotaService(ModelContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// busca uma entidade NotasModel pelo id informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>um objeto do tipo NotasModel</returns>
        public async Task<NotasModel> GetIdAsync(int? id)
        {
            return await context.NotasModels.FirstOrDefaultAsync(x => x.Id == id);
        }
        /// <summary>
        /// busca todas as entiadades do tipo NotasModel no banco de dados
        /// </summary>
        /// <returns>um objeto do tipo NotasModel</returns>
        public async Task<List<NotasModel>> ListAsync(int? id)
        {
            var notas =  await context.NotasModels.Where(x => x.IdAluno == id).ToListAsync();
           return  notas;
        }
    }
}
