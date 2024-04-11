using SistemaEducacional.Models;

namespace SistemaEducacional.Services.Interfaces
{
    public interface INota
    {
        public Task<NotasModel> GetIdAsync(int? id);
        public Task<List<NotasModel>> ListAsync(int? id);
    }
}
