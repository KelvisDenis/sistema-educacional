using SistemaEducacional.Models;

namespace SistemaEducacional.Services.Interfaces
{
    /// <summary>
    /// Interface define contrato com a classe DocenteService
    /// usado para Introduzir as ações a serem feitas na classe DocenteService, onde se manipula a entidade
    /// Docente
    /// </summary>
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
