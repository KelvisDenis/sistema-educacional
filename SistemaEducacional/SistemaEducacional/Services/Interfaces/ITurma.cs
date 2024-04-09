using SistemaEducacional.Models;

namespace SistemaEducacional.Services.Interfaces
{
    public interface ITurma
    {
        public Task CreateAsync(TurmaModel? model);
        public Task<TurmaModel> GetIdAsync(int? id);
        public Task<TurmaModel> GetAsync(string? nome);
        public Task<ICollection<TurmaModel>> ListAsync();
        public Task DeleteAsync(int? id);
        public Task UpdateAsync(TurmaModel? model);
    }
}
