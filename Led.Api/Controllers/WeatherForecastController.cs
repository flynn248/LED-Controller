using Led.Database.Ef;
using Microsoft.AspNetCore.Mvc;
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
  public IActionResult Get()
  {
    //JsonSerializer.Deserialize();

    try
    {
      var ledStripType = _dbContext.LedStripTypes.First();

      if (ledStripType is null)
      {
        return NoContent();
      }

      return Ok(JsonSerializer.Serialize(ledStripType));
    }
    catch (Exception)
    {

      return BadRequest();
    }
  }
}
