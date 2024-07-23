using Led.Database.Ef.Infrastructure.Interface;

namespace Led.Database.Ef.EntityModel;

public class LedStrip : IDateMetadataUtc
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public uint LedCount { get; set; }
  public int LedStripTypeId { get; set; }
  public DateTime CreatedDateUtc { get; set; }
  public DateTime? ModifiedDateUtc { get; set; }
  public virtual LedStripTypeList LedStripType { get; set; } = null!;
}
