using System.Drawing;

namespace Led.Database.Ef.EntityModel;

public class LED
{
  public int Id { get; set; }
  public string HexCode { get; set; }

  public LED()
  {
    HexCode = ColorTranslator.ToHtml(Color.Red);
    var a = int.Parse(HexCode, System.Globalization.NumberStyles.HexNumber);
  }
}
