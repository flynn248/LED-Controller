using Led.Database.Ef.Constants;
using Led.Database.Ef.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Led.Database.Ef.Configuration;
internal class LedStripTypeListConfiguration : IEntityTypeConfiguration<LedStripTypeList>
{
  public void Configure(EntityTypeBuilder<LedStripTypeList> builder)
  {
    builder.ToTable("LedStripTypeList", SchemaNames.Led);

    builder.HasKey(x => x.Id);

    builder.Property(x => x.Name)
      .HasMaxLength(100);

    builder.Property(x => x.Description)
      .HasMaxLength(500);

    builder.HasData(GetSeedData());
  }

  private IEnumerable<LedStripTypeList> GetSeedData()
  {
    return
    [
      new LedStripTypeList
      {
        Id = 1,
        Name = "WS2812B",
        Description = "Individually addressable.",
        SortOrder = 1
      }
    ];
  }
}
