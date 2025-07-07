using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Context
{
    public class CinemaDbContextFactory : IDesignTimeDbContextFactory<CinemaDbContext>
    {
        //public CinemaDbContext CreateDbContext(string[] args)
        //{
        //    // 1. Carga la configuración
        //    //    desde appsettings.json dl proyecto de inicio (WebCinema)
        //    var configuration = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //        .Build();
        //    // 2. Obtiene la cadena de conexión
        //    var connectionString = configuration.GetConnectionString("DefaultConnection");
        //    // 3. Configura DbContextOptions para usar SQL Server
        //    var optionsBuilder = new DbContextOptionsBuilder<CinemaDbContext>();
        //    optionsBuilder.UseSqlServer(connectionString);

        //    // 4. Crea y devuelve una nueva instancia de tu DbContext
        //    return new CinemaDbContext(optionsBuilder.Options);
        //}
        public CinemaDbContext CreateDbContext(string[] args)
        {
            var connection = "Server=localhost;Database=Cinema;User ID=sa;Password=123;TrustServerCertificate=True;";
            //var connection = "Server=(localdb)\\MSSQLLocalDB;Database=Cinema;Trusted_Connection=True;Trusted_Connection=True;";

            var optionsBuilder = new DbContextOptionsBuilder<CinemaDbContext>();
            optionsBuilder.UseSqlServer(connection);

            return new CinemaDbContext(optionsBuilder.Options);
        }
    }
}
