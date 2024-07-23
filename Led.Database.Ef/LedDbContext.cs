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
  public virtual DbSet<LedConfigStage> LedConfigStages { get; set; }
  public virtual DbSet<LedNode> LedNodes { get; set; }
  public virtual DbSet<LedStrip> LedStrips { get; set; }
  public virtual DbSet<LedStripTypeList> LedStripTypes { get; set; }
  #endregion

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.AddInterceptors(new DateMetaDataInterceptor());

#if APIDEBUG || MIGRATIONDEBUG
    optionsBuilder.EnableSensitiveDataLogging(true)
      .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
#endif
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(LedDbContext).Assembly);

    var modelForeignKeys = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());

    foreach (var foreignKey in modelForeignKeys)
    {
      foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
    }

    base.OnModelCreating(modelBuilder);
  }
}
