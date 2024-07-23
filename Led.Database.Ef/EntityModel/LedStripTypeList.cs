namespace Led.Database.Ef.EntityModel;

public class LedStripTypeList
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }

  public LedStripTypeList()
  {
    Name = string.Empty;
    Description = string.Empty;
  }
}
