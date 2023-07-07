using CarritoFinal.Models;

namespace CarritoFinal.Service
{
    public interface IMarca
    {
        void add(Marca obj);
        IEnumerable<Marca> GetAllMarcas();
        void remove(string id);
        Marca edit(string id);
        void editDetails(Marca obj);
    }
}
