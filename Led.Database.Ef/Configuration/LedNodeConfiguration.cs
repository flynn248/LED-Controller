using Led.Database.Ef.Constants;
using Led.Database.Ef.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Led.Database.Ef.Configuration;
internal class LedNodeConfiguration : IEntityTypeConfiguration<LedNode>
{
  public void Configure(EntityTypeBuilder<LedNode> builder)
  {
    builder.ToTable("LedNode", SchemaNames.Led);

    builder.HasKey(x => x.Id);

    builder.Property(x => x.Rgba)
      .HasColumnName("RGBA");

    builder.HasOne<LedStrip>()
      .WithMany(x => x.LedNodes)
      .HasForeignKey(x => x.LedStripId);
  }
}
