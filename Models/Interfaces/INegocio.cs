using Models;
using System.Web.Http;

namespace Models.Interfaces
{
    public interface INegocio
    {
         Task<List<Alimento>> GetAll();
        Task<List<Ingrediente>> GetIngredientes(int id);
        Task<bool> DeleteAlimentos(int id);
        Task<int> AgregarAlimentos( Alimento request);
        
    }
}
