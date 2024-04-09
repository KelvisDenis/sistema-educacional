using SistemaEducacional.Models;

namespace SistemaEducacional.Services.Session
{
    public interface Isession
    {
        public void CreateSession(DirecaoModel model);
        public void RemoveSession();
        public DirecaoModel GetSession();
    }
}
