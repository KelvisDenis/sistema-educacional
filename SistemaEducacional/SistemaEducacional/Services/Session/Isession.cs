using SistemaEducacional.Models;

namespace SistemaEducacional.Services.Session
{
    /// <summary>
    /// Define contrato com a classe Sessao
    /// usada para vincular usuario a uma sessão 
    /// possui os metodos : CreateSession, RemoveSession, GetSession
    /// </summary>
    public interface Isession
    {
        public void CreateSession(DirecaoModel model);
        public void RemoveSession();
        public DirecaoModel GetSession();
    }
}
