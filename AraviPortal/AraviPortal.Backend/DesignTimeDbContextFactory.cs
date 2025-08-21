using AraviPortal.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AraviPortal.Backend;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        // Esto crea un constructor de configuración.
        // Carga el archivo appsettings.json para acceder a la cadena de conexión.
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json") // El archivo de configuración principal
            .Build();

        // Configura las opciones del DbContext.
        var builder = new DbContextOptionsBuilder<DataContext>();

        // Lee la cadena de conexión desde appsettings.json.
        // Asegúrate de que el nombre del ConnectionString sea el correcto.
        // Si en tu appsettings.json tienes "LocalConnection" dentro de "ConnectionStrings",
        // entonces el nombre correcto es "ConnectionStrings:LocalConnection".
        var connectionString = configuration.GetConnectionString("LocalConnection");

        // Utiliza el proveedor de base de datos SQL Server.
        builder.UseSqlServer(connectionString);

        // Retorna una nueva instancia del DbContext con las opciones configuradas.
        return new DataContext(builder.Options);
    }
}