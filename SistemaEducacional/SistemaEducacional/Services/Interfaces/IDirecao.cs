using SistemaEducacional.Models;

namespace SistemaEducacional.Services.Interfaces
{
    /// <summary>
    /// Interface define contrato com a classe DirecaoService
    /// usado para Introduzir as ações a serem feitas na classe DirecaoService, onde se manipula a entidade
    /// Direcao
    /// </summary>
    public interface IDirecao
    {
        public Task CreateAsync(DirecaoModel model);
        public Task<DirecaoModel> GetIdAsync(int? id);
        public Task<DirecaoModel> GetLoginAsync(string? user);
        public  Task<DirecaoModel> GetAsync(string? user);
        public Task<List<DirecaoModel>> ListAsync();
        public Task DeleteAsync(int? id);
        public Task UpdateAsync(DirecaoModel? model, string? senha);
    }
}
