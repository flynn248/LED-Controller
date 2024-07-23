using Led.Database.Ef.Constants;
using Led.Database.Ef.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Led.Database.Ef.Configuration;
internal class LedStripConfiguration : IEntityTypeConfiguration<LedStrip>
{
  public void Configure(EntityTypeBuilder<LedStrip> builder)
  {
    builder.ToTable("LedStrip", SchemaNames.Led);

    builder.HasKey(x => x.Id);

    builder.Property(x => x.Name)
      .HasMaxLength(100);

    builder.Property(x => x.Description)
      .HasMaxLength(500);

    builder.HasOne(x => x.LedStripType)
      .WithMany()
      .HasForeignKey(x => x.LedStripTypeId);
  }
}
