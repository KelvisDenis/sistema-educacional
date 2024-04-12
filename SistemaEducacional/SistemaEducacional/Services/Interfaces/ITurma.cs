using SistemaEducacional.Models;

namespace SistemaEducacional.Services.Interfaces
{
    /// <summary>
    /// Interface define contrato com a classe TurmaService
    /// usado para Introduzir as ações a serem feitas na classe TurmaService, onde se manipula a entidade
    /// Turma
    /// </summary>
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
