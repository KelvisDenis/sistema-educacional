using SistemaEducacional.Models;

namespace SistemaEducacional.Services.Interfaces
{
    /// <summary>
    /// Interface define contrato com a classe NotaService
    /// usado para Introduzir as ações a serem feitas na classe NotaService, onde se manipula a entidade
    /// Nota
    /// </summary>
    public interface INota
    {
        public Task<NotasModel> GetIdAsync(int? id);
        public Task<List<NotasModel>> ListAsync(int? id);
    }
}
