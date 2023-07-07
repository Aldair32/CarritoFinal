using CarritoFinal.Models;

namespace CarritoFinal.Service
{
    public interface ICategoria
    {
        void add(Categoria obj);
        IEnumerable<Categoria> GetAllCategorias();
        void remove(string id);
        Categoria edit(string id);
        void editDetails(Categoria obj);
    }
}
