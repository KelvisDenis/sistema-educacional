using Microsoft.AspNetCore.Mvc;

namespace SistemaEducacional.Controllers
{
    public class TurmaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
