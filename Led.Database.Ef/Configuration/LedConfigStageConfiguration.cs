using Led.Database.Ef.Constants;
using Led.Database.Ef.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Led.Database.Ef.Configuration;
internal class LedConfigStageConfiguration : IEntityTypeConfiguration<LedConfigStage>
{
  public void Configure(EntityTypeBuilder<LedConfigStage> builder)
  {
    builder.ToTable("LedConfigStage", SchemaNames.Led);

    builder.HasKey(x => x.Id);

    builder.Property(x => x.Name)
      .HasMaxLength(50);
  }
}
