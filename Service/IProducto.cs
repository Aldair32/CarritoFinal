using CarritoFinal.Models;

namespace CarritoFinal.Service
{
    public interface IProducto
    {
        void add(Producto obj);
        IEnumerable<Producto> GetAllProductos();
        void remove(string id);
        Producto edit(string id);
        void editDetails(Producto obj);
    }
}
