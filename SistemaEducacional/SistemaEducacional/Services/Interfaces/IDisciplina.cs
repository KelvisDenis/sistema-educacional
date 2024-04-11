using SistemaEducacional.Models;

namespace SistemaEducacional.Services.Interfaces
{
    public interface IDisciplina
    {
        public Task CreateAsync(DisciplinaModel? model);
        public Task<DisciplinaModel> GetAsync(string? nome);
        public Task<DisciplinaModel> GetIdAsync(int? id);
        public Task<List<DisciplinaModel>> ListAsync();
        public Task DeleteAsync(int? id);
        public Task UpdateAsync(DisciplinaModel model);
    }
}
