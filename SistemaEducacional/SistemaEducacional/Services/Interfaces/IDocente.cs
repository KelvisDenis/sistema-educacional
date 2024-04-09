using SistemaEducacional.Models;

namespace SistemaEducacional.Services.Interfaces
{
    public interface IDocente
    {
        public Task CreateAsync(DocenteModel? model);
        public Task<DocenteModel> GetIdAsync(int? id);
        public Task<DocenteModel> GetAsync(string? nome);
        public Task<ICollection<DocenteModel>> ListAsync();
        public Task DeleteAsync(int? id);
        public Task UpdateAsync(DocenteModel model);
    }
}
