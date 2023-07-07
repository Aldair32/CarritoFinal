using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarritoFinal.Models;
using CarritoFinal.Service;


namespace CarritoFinal.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoria _categoria;
        public CategoriaController(ICategoria categoria)
        {
            _categoria = categoria;
        }
        //public IActionResult Index()
        //{
        //    return View(_categoria.GetAllCategorias());
        //}
        public IActionResult Index(DateTime? fechaInicio, DateTime? fechaFin)
        {
            var categorias = _categoria.GetAllCategorias();

            if (fechaInicio.HasValue && fechaFin.HasValue)
            {
                categorias = categorias.Where(c => c.FechaRegistro >= fechaInicio && c.FechaRegistro <= fechaFin);
            }

            return View(categorias);
        }
        [Route("Categoria/Eliminar/{codigo}")]
        public IActionResult eliminar(string codigo)
        {
            _categoria.remove(codigo);
            return RedirectToAction("Index");
        }
        public IActionResult Nuevo()
        {
            return View();
        }
        public IActionResult Grabar(Categoria obj)
        {
            _categoria.add(obj);
            return RedirectToAction("Index");
        }
        [Route("Categoria/Editar/{codigo}")]
        public IActionResult Editar(string codigo)
        {
            return View(_categoria.edit(codigo));
        }
        public IActionResult editarCategoria(Categoria obj)
        {
            _categoria.editDetails(obj);
            return RedirectToAction("Index");
        }
    }
}
