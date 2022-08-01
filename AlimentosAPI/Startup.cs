using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using AlimentosAPI.Models;
using AlimentosAPI.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
//using AspNETCore_StoreprocedureDemo.data;


namespace AlimentosAPI
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }   

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {


            services.AddTransient<Metodo, Metodo>();
            //services.AddSingleton<Metodo>(new Metodo(Configuration.Get<Metodo>()));
            services.AddScoped<Metodo, Metodo > ();


            services.AddMvcCore();
            
            //services.AddDbContext<AlimentosContext>();
            services.AddDbContext<AlimentosContext>(options =>
       options.UseSqlServer(Configuration.GetConnectionString("CadenaSQLAlimentos")));
        /*aqui agregamos la policy para cors que se requieren para el backend con el fron end de diferentes tecnologias*/
            services.AddCors((options => options.AddPolicy("AllowWebApp",
                builder => builder.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod())));
        }

        public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors("AllowWebApp");

            app.UseRouting();
        }
 
       
    }
}
