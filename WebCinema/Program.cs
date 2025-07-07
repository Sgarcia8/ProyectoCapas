using Core.Interfaces;
using Infraestructure.Context;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CinemaDbContext>(options =>
    options.UseSqlServer(connectionString));


// Registro de repositorio generico
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Registro de servicio generico
builder.Services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.  
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "WebCinema API V1");
    }
    );
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
