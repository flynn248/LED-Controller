using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Led.Database.Ef.Migrations;

public class LedDbContextFactory : IDesignTimeDbContextFactory<LedDbContext>
{
  public LedDbContext CreateDbContext(string[] args)
  {
    IConfigurationRoot configuraiton = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json")
      .AddUserSecrets<Program>()
      .Build();

    var connectionString = configuraiton.GetConnectionString("Default");

    var optionsBuilder = new DbContextOptionsBuilder<LedDbContext>();
    optionsBuilder.UseNpgsql(connectionString, options =>
    {
      options.MigrationsAssembly(typeof(LedDbContextFactory).Assembly.FullName); // Worked. Put migrations in this assembly
    });

    return new LedDbContext(optionsBuilder.Options);
  }
}
