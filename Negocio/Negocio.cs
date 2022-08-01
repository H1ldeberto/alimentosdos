
using Datos;
using Models;
using Models.Interfaces;
using System.Web.Http;

namespace Negocio
{
    //se realiza el contrato para la implementacion de metodos
    public class Negocio : INegocio


    {
        private IDatos datos;
        public Negocio(IDatos datos)
        {
            this.datos = datos;
        }

        public async Task<List<Alimento>> GetAll()
        {
            
            return await this.datos.GetAll();
        }

        public async Task<List<Ingrediente>> GetIngredientes(int id)
        {
            return await this.datos.GetIngredientes(id);
        }

        
             public async Task<bool> DeleteAlimentos(int id)
        {
            return await this.datos.DeleteAlimentos(id);
        }

        public async Task<int> AgregarAlimentos( Alimento request)
        {
            var id= await this.datos.AgregarAlimentos(request);
            request.Ingrediente.ForEach(async ingrediente=>{
                ingrediente.Idalimentos = id;
                await this.datos.AgregarIngredientes(ingrediente);
            });
            return id;
        }
    }
}