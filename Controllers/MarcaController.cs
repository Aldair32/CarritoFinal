using Microsoft.AspNetCore.Mvc;
using CarritoFinal.Models;
using CarritoFinal.Service;

namespace CarritoFinal.Controllers
{
    public class MarcaController : Controller
    {
        private readonly IMarca _marca;
        public MarcaController(IMarca marca)
        {
            _marca = marca;
        }
        public IActionResult Index()
        {
            return View(_marca.GetAllMarcas());
        }
        [Route("Marca/Eliminar/{codigo}")]
        public IActionResult eliminar(string codigo)
        {
            _marca.remove(codigo);
            return RedirectToAction("Index");
        }
        public IActionResult Nuevo()
        {
            return View();
        }
        public IActionResult Grabar(Marca obj)
        {
            _marca.add(obj);
            return RedirectToAction("Index");
        }
        [Route("Marca/Editar/{codigo}")]
        public IActionResult Editar(string codigo)
        {
            return View(_marca.edit(codigo));
        }
        public IActionResult editarMarca(Marca obj)
        {
            _marca.editDetails(obj);
            return RedirectToAction("Index");
        }
    }
}
