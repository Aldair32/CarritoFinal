using CarritoFinal.Models;
using System.Globalization;

namespace CarritoFinal.Service
{
	public interface IUsuario
	{
		void add(Usuario obj);
		IEnumerable<Usuario> GetAllUsuarios();
		void remove(string id);
		Usuario edit(string id);
		void editDetails(Usuario obj);
	}
}
