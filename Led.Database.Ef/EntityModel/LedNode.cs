using System.Drawing;

namespace Led.Database.Ef.EntityModel;

public class LedNode
{
  public int Id { get; set; }
  public int Rgba { get; set; }
  public short? White { get; set; }
}
