using Microsoft.EntityFrameworkCore;
using SistemaEducacional.Infraestrutura;
using SistemaEducacional.Models;
using SistemaEducacional.Services.Interfaces;

namespace SistemaEducacional.Services
{
    public class NotaService : INota
    {
        private readonly ModelContext context;

        public NotaService(ModelContext context)
        {
            this.context = context;
        }
        public async Task<NotasModel> GetIdAsync(int? id)
        {
            return await context.NotasModels.FirstOrDefaultAsync(x => x.Id == id);
        }

        public  async Task<List<NotasModel>> ListAsync(int? id)
        {
            var notas =  await context.NotasModels.Where(x => x.IdAluno == id).ToListAsync();
           return  notas;
        }
    }
}
