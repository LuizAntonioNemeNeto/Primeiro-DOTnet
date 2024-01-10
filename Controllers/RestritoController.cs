using Sisteminha.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Sisteminha.Controllers
{
    [PaginaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
