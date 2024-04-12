using SistemaEducacional.Models;

namespace SistemaEducacional.Services.Interfaces
{
    /// <summary>
    /// Interface define contrato com a classe DisciplinaService
    /// usado para Introduzir as ações a serem feitas na classe DisciplinaService, onde se manipula a entidade
    /// Disciplina
    /// </summary>
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
