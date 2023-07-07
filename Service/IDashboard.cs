using CarritoFinal.Models;

namespace CarritoFinal.Service
{
    public interface IDashboard
    {
        void add(DetalleVenta obj);
        IEnumerable<DetalleVenta> GetAllDetalleVentas();
        //void remove(string id);
        //Producto edit(string id);
        //void editDetails(Producto obj);
    }
}
