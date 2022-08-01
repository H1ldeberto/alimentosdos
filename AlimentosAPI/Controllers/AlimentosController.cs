using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Interfaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlimentosAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/")]

    [ApiController]
    public class AlimentosController : ControllerBase
    {
       
        //inyeccion de dependencias son tres puntos 
        //1.-crear clase e interfaz, y adicionalmente la clase debe heredar a la interfaz
        //2.-configuracion en program 
        //3.-invocar la inyeccion de depencias por constructor

        private readonly INegocio negocio;
       

        //creamos nuestro constructor (ctor + 2 tab)
        public AlimentosController(INegocio negocio)
        {
            this.negocio = negocio;
           
        }

       

        // GET: api/<FootController>
        [HttpGet]
        [Route("comida")]
        public async Task<List<Alimento>> GetAll()
        {
           var list = await this.negocio.GetAll();
            
            return list;
        }


      
        [HttpPost]
        [Route("comida")]
        public async Task<int> AgregarAlimentos([FromBody] Alimento request)
        {
           var result = await this.negocio.AgregarAlimentos(request);

            return result;
        }


        [HttpGet]
        [Route("comida/ingredientes/{id}")]
        public async Task<List<Ingrediente>> GetIngredientes(int id)
        {
            
            var list = await this.negocio.GetIngredientes(id);

            return list;
        }

        [HttpDelete]
        [Route("comida/{id}")]
        public async Task<bool> DeleteAlimentos(int id)
        {

            var result = await this.negocio.DeleteAlimentos(id);

            return result;
        }



    }
}
