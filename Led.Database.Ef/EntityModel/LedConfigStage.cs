using Led.Database.Ef.Infrastructure.Interface;

namespace Led.Database.Ef.EntityModel;

public class LedConfigStage : IDateMetadataUtc
{
  public int Id { get; set; }
  public string Name { get; set; }
  public int SortOrder { get; set; }
  public TimeSpan Duration { get; set; }
  public DateTime CreatedDateUtc { get; set; }
  public DateTime? ModifiedDateUtc { get; set; }

  public LedConfigStage()
  {
    Name = string.Empty;
  }
}
