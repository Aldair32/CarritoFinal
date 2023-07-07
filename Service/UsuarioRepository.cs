using CarritoFinal.Models;

namespace CarritoFinal.Service
{
	public class UsuarioRepository : IUsuario
	{
		private CarritoC conexion = new CarritoC();
		public void add(Usuario obj)
		{
			try
			{
				conexion.Usuarios.Add(obj);
				conexion.SaveChanges();
			}
			catch (Exception e)
			{
				Console.WriteLine("Ocurrio un error al grabar los datos!", e.Message);
			}
		}

		public Usuario edit(string id)
		{
			var obj = (from usu in conexion.Usuarios
					   where usu.CdUsuario == id
					   select usu).Single();
			return obj;
		}

		public void editDetails(Usuario obj)
		{
			var objAModificar =
						(from usu in conexion.Usuarios
						 where usu.CdUsuario == obj.CdUsuario
						 select usu).Single();
			objAModificar.Nombres = obj.Nombres;
            objAModificar.Apellidos = obj.Apellidos;
            objAModificar.Correo = obj.Correo;
            objAModificar.Activo = obj.Activo;
            conexion.SaveChanges();
		}

		public IEnumerable<Usuario> GetAllUsuarios()
		{
			return conexion.Usuarios;
		}

		public void remove(string id)
		{
			var obj = (from usu in conexion.Usuarios
					   where usu.CdUsuario == id
					   select usu).Single();
			conexion.Remove(obj);
			conexion.SaveChanges();
		}
	}
}
