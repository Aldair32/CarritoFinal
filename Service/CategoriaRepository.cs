using CarritoFinal.Models;

namespace CarritoFinal.Service
{
    public class CategoriaRepository : ICategoria
    {
        private CarritoC conexion = new CarritoC();
        public void add(Categoria obj)
        {
            try
            {
                conexion.Categoria.Add(obj);
                conexion.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrio un error al grabar los datos!", e.Message);
            }
        }

        public Categoria edit(string id)
        {
            var obj = (from ctg in conexion.Categoria
                       where ctg.CdCategoria == id
                       select ctg).Single();
            return obj;
        }

        public void editDetails(Categoria obj)
        {
            var objAModificar =
                         (from ctg in conexion.Categoria
                          where ctg.CdCategoria == obj.CdCategoria
                          select ctg).Single();
            objAModificar.Descripcion = obj.Descripcion;
            objAModificar.Activo = obj.Activo;
            conexion.SaveChanges();
        }

        public IEnumerable<Categoria> GetAllCategorias()
        {
            return conexion.Categoria;
        }

        public void remove(string id)
        {
            var obj = (from ctg in conexion.Categoria
                       where ctg.CdCategoria == id
                       select ctg).Single();
            conexion.Remove(obj);
            conexion.SaveChanges();
        }
    }
}
