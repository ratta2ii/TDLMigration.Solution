using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TDLMigration.Models
{
  public class TDLMigrationContextFactory : IDesignTimeDbContextFactory<TDLMigrationContext>
  {

    TDLMigrationContext IDesignTimeDbContextFactory<TDLMigrationContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<TDLMigrationContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new TDLMigrationContext(builder.Options);
    }
  }
}