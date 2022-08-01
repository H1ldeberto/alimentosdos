using Microsoft.EntityFrameworkCore;
using Models.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//aqui se declara el punto dos quees punto de entrada de la inyeccion de dependencias

builder.Services.AddTransient<IDatos, Datos.Datos>();

builder.Services.AddTransient<INegocio, Negocio.Negocio> ();

//servicios para la interfaz a angular
builder.Services.AddCors((options => options.AddPolicy("AllowWebApp",
                builder => builder.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod())));

void options(DbContextOptionsBuilder obj)
{
    throw new NotImplementedException();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseCors("AllowWebApp");

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();


app.Run();
