using Led.Database.Ef;
using Led.Database.Ef.EntityModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Led.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
  private readonly LedDbContext _dbContext;

  public WeatherForecastController(LedDbContext context)
  {
    _dbContext = context;
  }

  [HttpGet("GetWeatherForecast")]
  public async Task<IActionResult> Get()
  {
    //JsonSerializer.Deserialize();

    try
    {
      //var ledStripType = _dbContext.LedStripTypes.First();

      //await SetData();


      //if (ledStripType is null)
      //{
      //  return NoContent();
      //}

      return Ok(JsonSerializer.Serialize(
        _dbContext.LedStrips.Include(x => x.LedNodes).First(x => x.Id == 1),
        new JsonSerializerOptions()
        {
          WriteIndented = true
        }));
    }
    catch (Exception)
    {

      return BadRequest();
    }
  }

  private async Task SetData()
  {
    var ledStrip = _dbContext.LedStrips
      .Include(x => x.LedNodes)
      .First(x => x.Id == 1);

    ledStrip.LedNodes.Add(new LedNode()
    {
      Rgba = Color.Blue.ToArgb()
    });

    //_dbContext.LedStrips.Update(
    //{
    //  LedNodes = new List<LedNode>()
    //    {

    //    }
    //});

    await _dbContext.SaveChangesAsync();
  }
}
