using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Coordinator.Web.Data;

public class PgSqlDbContextFactory : IDesignTimeDbContextFactory<PgSqlDbContext>
{
    public PgSqlDbContext CreateDbContext(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddJsonFile("appsettings.json");
        configurationBuilder.AddUserSecrets(Assembly.GetAssembly(typeof(PgSqlDbContext)));
        var configuration = configurationBuilder.Build();

        var connectionString = configuration.GetConnectionString("PgSqlConnection");

        var optionsBuilder = new DbContextOptionsBuilder<PgSqlDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new PgSqlDbContext(optionsBuilder.Options);
    }
}