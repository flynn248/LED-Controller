using Led.Database.Ef.EntityModel;
using Led.Database.Ef.Infrastructure.Interceptor;
using Microsoft.EntityFrameworkCore;

namespace Led.Database.Ef;

public class LedDbContext : DbContext
{
  public LedDbContext()
  {
  }

  public LedDbContext(DbContextOptions<LedDbContext> dbContextOptions)
    : base(dbContextOptions)
  {
  }

  #region LED
  public virtual DbSet<LedStrip> LedStrips { get; set; }
  public virtual DbSet<LED> Leds { get; set; }
  public virtual DbSet<LedStripTypeList> LedStripTypes { get; set; }
  #endregion

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.AddInterceptors(new DateMetaDataInterceptor());

    optionsBuilder.UseNpgsql();

#if DEBUG
    optionsBuilder.EnableSensitiveDataLogging(true)
      .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
#endif
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(LedDbContext).Assembly);

    base.OnModelCreating(modelBuilder);
  }
}
