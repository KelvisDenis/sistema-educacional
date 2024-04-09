using Microsoft.AspNetCore.Mvc;

namespace SistemaEducacional.Controllers
{
    public class AlunoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
