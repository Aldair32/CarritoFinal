using Microsoft.AspNetCore.Mvc;

namespace CarritoFinal.Controllers
{
    public class TiendaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
