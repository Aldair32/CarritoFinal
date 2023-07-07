using CarritoFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace CarritoFinal.Service
{
    public class DashboardRepository : IDashboard
    {
        private CarritoC conexion = new CarritoC();

        public void add(DetalleVenta obj)
        {
            try
            {
                conexion.DetalleVenta.Add(obj);
                conexion.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrio un error al grabar los datos!", e.Message);
            }
        }

        public IEnumerable<DetalleVenta> GetAllDetalleVentas()
        {
            return conexion.DetalleVenta.Include(p => p.CdvEntaNavigation)
                                        .Include(p => p.CdProductoNavigation)
                                        .Include(p => p.CdvEntaNavigation.CdClienteNavigation)
                                   ;
        }
    }
}
