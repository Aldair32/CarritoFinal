using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarritoFinal.Models;
using CarritoFinal.Service;

namespace CarritoFinal.Controllers
{
	public class UsuarioController : Controller
	{
		private readonly IUsuario _usuario;
		public UsuarioController(IUsuario usuario)
		{
			_usuario = usuario;
		}
		public IActionResult Index()
		{
			return View(_usuario.GetAllUsuarios());
		}
		[Route("Usuario/Eliminar/{codigo}")]
		public IActionResult eliminar(string codigo)
		{
			_usuario.remove(codigo);
			return RedirectToAction("Index");
		}
		public IActionResult Nuevo()
		{
			return View();
		}
		public IActionResult Grabar(Usuario obj)
		{
			_usuario.add(obj);
			return RedirectToAction("Index");
		}
		[Route("Usuario/Editar/{codigo}")]
		public IActionResult Editar(string codigo)
		{
			return View(_usuario.edit(codigo));
		}
		public IActionResult editarUsuario(Usuario obj)
		{
			_usuario.editDetails(obj);
			return RedirectToAction("Index");
		}
	}
}
