using Led.Database.Ef.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Led.Database.Ef.Infrastructure.Interceptor;

internal class DateMetaDataInterceptor : SaveChangesInterceptor
{
  public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
  {
    if (eventData.Context is null || eventData.Context is not LedDbContext context)
    {
      return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    var entries = context.ChangeTracker.Entries<IDateMetadataUtc>();

    if (!entries.Any())
    {
      return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    foreach (var entry in entries)
    {
      if (entry.State == EntityState.Added)
      {
        entry.Property<DateTime>(nameof(IDateMetadataUtc.CreatedDateUtc)).CurrentValue = DateTime.UtcNow;
      }

      if (entry.State == EntityState.Modified)
      {
        entry.Property<DateTime>(nameof(IDateMetadataUtc.CreatedDateUtc)).IsModified = false;
        entry.Property<DateTime?>(nameof(IDateMetadataUtc.ModifiedDateUtc)).CurrentValue = DateTime.UtcNow;
      }
    }

    return base.SavingChangesAsync(eventData, result, cancellationToken);
  }
}
