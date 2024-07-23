using Microsoft.EntityFrameworkCore;

namespace Led.Database.Ef.Migrations;

internal class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("Staring migration...");

    var factory = new LedDbContextFactory();

    using (var context = factory.CreateDbContext(Array.Empty<string>()))
    {
      try
      {
        context.Database.Migrate();
        Console.WriteLine("Migration Success!");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Migration failed!\r\n{ex.Message}");
      }
    }
  }
}
