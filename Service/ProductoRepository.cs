using CarritoFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace CarritoFinal.Service
{
    public class ProductoRepository : IProducto
    {
        private CarritoC conexion = new CarritoC();
        public void add(Producto obj)
        {
            try
            {
                conexion.Productos.Add(obj);
                conexion.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrio un error al grabar los datos!", e.Message);
            }
        }

        public Producto edit(string id)
        {
            var obj = (from pdt in conexion.Productos
                       where pdt.CdProducto == id
                       select pdt).Single();
            return obj;
        }

        public void editDetails(Producto obj)
        {
            var objAModificar =
                (from pdt in conexion.Productos
                where pdt.CdProducto == obj.CdProducto
                select pdt).Single();
            objAModificar.Nombre = obj.Nombre;
            objAModificar.Descripcion = obj.Descripcion;
            objAModificar.CdMarca =     obj.CdMarca;
            objAModificar.CdCategoria = obj.CdCategoria;
            objAModificar.Precio = obj.Precio;
            objAModificar.Stock = obj.Stock;
            objAModificar.Activo = obj.Activo;
            conexion.SaveChanges();
        }

        public IEnumerable<Producto> GetAllProductos()
        {
            return conexion.Productos.Include(p => p.CdMarcaNavigation)
                                     .Include(p => p.CdCategoriaNavigation)
                                     ;
        }

        public void remove(string id)
        {
            var obj = (from pdt in conexion.Productos
                       where pdt.CdProducto == id
                       select pdt).Single();
            conexion.Remove(obj);
            conexion.SaveChanges();
        }
    }
}
