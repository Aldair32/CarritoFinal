using CarritoFinal.Models;

namespace CarritoFinal.Service
{
    public class MarcaRepository : IMarca
    {
        private CarritoC conexion = new CarritoC();
        public void add(Marca obj)
        {
            try
            {
                conexion.Marcas.Add(obj);
                conexion.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrio un error al grabar los datos!", e.Message);
            }
        }

        public Marca edit(string id)
        {
            var obj = (from mrc in conexion.Marcas
                       where mrc.CdMarca == id
                       select mrc).Single();
            return obj;
        }

        public void editDetails(Marca obj)
        {
            var objAModificar =
             (from mrc in conexion.Marcas
              where mrc.CdMarca == obj.CdMarca
              select mrc).Single();
            objAModificar.Descripcion = obj.Descripcion;
            objAModificar.Activo = obj.Activo;
            conexion.SaveChanges();
        }

        public IEnumerable<Marca> GetAllMarcas()
        {
            return conexion.Marcas;
        }

        public void remove(string id)
        {
            var obj = (from mrc in conexion.Marcas
                       where mrc.CdMarca == id
                       select mrc).Single();
            conexion.Remove(obj);
            conexion.SaveChanges();
        }
    }
}
