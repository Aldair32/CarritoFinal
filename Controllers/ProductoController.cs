using Microsoft.AspNetCore.Mvc;
using CarritoFinal.Models;
using CarritoFinal.Service;


namespace CarritoFinal.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProducto _producto;
        public ProductoController(IProducto producto)
        {
            _producto = producto;
        }
        public IActionResult Index()
        {
            return View(_producto.GetAllProductos());
        }
        [Route("Producto/Eliminar/{codigo}")]
        public IActionResult eliminar(string codigo)
        {
            _producto.remove(codigo);
            return RedirectToAction("Index");
        }
        public IActionResult Nuevo()
        {
            return View();
        }
        public IActionResult Grabar(Producto obj)
        {
            _producto.add(obj);
            return RedirectToAction("Index");
        }
        [Route("Producto/Editar/{codigo}")]
        public IActionResult Editar(string codigo)
        {
            return View(_producto.edit(codigo));
        }
        public IActionResult editarProducto(Producto obj)
        {
            _producto.editDetails(obj);
            return RedirectToAction("Index");
        }
    }
}
