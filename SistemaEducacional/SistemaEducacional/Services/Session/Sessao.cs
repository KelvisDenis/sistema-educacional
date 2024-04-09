using Newtonsoft.Json;
using SistemaEducacional.Models;
using System.Text.Json.Serialization;

namespace SistemaEducacional.Services.Session
{
    public class Sessao : Isession
    {
        private readonly IHttpContextAccessor _Session;
        
        public Sessao(IHttpContextAccessor httpContext) 
        {
        _Session = httpContext;
        }
        public void CreateSession(DirecaoModel model)
        {
            var userJson = JsonConvert.SerializeObject(model);
            _Session.HttpContext.Session.SetString("user", userJson);   
        }

        public DirecaoModel GetSession()
        {
            var user = _Session.HttpContext.Session.GetString("user");
            if (user == null) return null;
            return JsonConvert.DeserializeObject<DirecaoModel>(user);
        }

        public void RemoveSession()
        {
            _Session.HttpContext.Session.Remove("user");
        }
    }
}
