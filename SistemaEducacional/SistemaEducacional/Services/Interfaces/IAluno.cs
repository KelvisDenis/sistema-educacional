using SistemaEducacional.Models;

namespace SistemaEducacional.Services.Interfaces
{
    public interface IAluno
    {
        public Task CreateAsync(AlunoModel model);
        public Task<AlunoModel> GetIdAsync(int? id);
        public Task<AlunoModel> GetAsync(string? nome);
        public Task<ICollection<AlunoModel>> ListAsync();
        public Task DeleteAsync(int? id);
        public Task UpdateAsync(AlunoModel? id);
    }
}
