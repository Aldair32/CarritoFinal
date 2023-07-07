using Microsoft.AspNetCore.Mvc;
using CarritoFinal.Models;
using CarritoFinal.Service;

namespace CarritoFinal.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboard _detalleVenta;
        public DashboardController(IDashboard detalleVenta)
        {
            _detalleVenta = detalleVenta;
        }
        public IActionResult Index()
        {
            return View(_detalleVenta.GetAllDetalleVentas());
        }   


    }
}
