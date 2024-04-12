using SistemaEducacional.Models;

namespace SistemaEducacional.Services.Interfaces
{
    /// <summary>
    /// Interface define contrato com a classe Aluno
    /// usado para Introduzir as ações a serem feitas na classe Aluno, onde se manipula a entidade
    /// Aluno
    /// </summary>
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
