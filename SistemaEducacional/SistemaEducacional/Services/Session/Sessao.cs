using Newtonsoft.Json;
using SistemaEducacional.Models;
using System.Text.Json.Serialization;

namespace SistemaEducacional.Services.Session
{
    /// <summary>
    /// Classe introduz a intarface Isession 
    /// usada para atuar com a sessão do usuario
    /// </summary>
    public class Sessao : Isession
    {
        /// <summary>
        /// recebe por meio de injeção de dependência a interface IHttpContextAccessor
        /// </summary>
        private readonly IHttpContextAccessor _Session;

        /// <summary>
        /// construtor que recebe IHttpContextAccessor
        /// </summary>
        /// <param name="httpContext"></param>
        public Sessao(IHttpContextAccessor httpContext) 
        {
        _Session = httpContext;
        }
        /// <summary>
        /// Metodo cria a sessão do usuario
        /// </summary>
        /// <param name="model"></param>
        public void CreateSession(DirecaoModel model)
        {
            var userJson = JsonConvert.SerializeObject(model);
            _Session.HttpContext.Session.SetString("user", userJson);   
        }
        /// <summary>
        /// metodo busca a sessão do usuario
        /// </summary>
        /// <returns></returns>
        public DirecaoModel GetSession()
        {
            var user = _Session.HttpContext.Session.GetString("user");
            if (user == null) return null;
            return JsonConvert.DeserializeObject<DirecaoModel>(user);
        }
        /// <summary>
        /// metodo remove a sessão do usuario
        /// </summary>
        public void RemoveSession()
        {
            _Session.HttpContext.Session.Remove("user");
        }
    }
}
