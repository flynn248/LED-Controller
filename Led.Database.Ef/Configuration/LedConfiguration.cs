using Led.Database.Ef.Constants;
using Led.Database.Ef.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Led.Database.Ef.Configuration;
internal class LedConfiguration : IEntityTypeConfiguration<LED>
{
  public void Configure(EntityTypeBuilder<LED> builder)
  {
    builder.ToTable("Led", SchemaNames.Led);

    builder.Property(x => x.HexCode)
      .HasMaxLength(9);
  }
}
