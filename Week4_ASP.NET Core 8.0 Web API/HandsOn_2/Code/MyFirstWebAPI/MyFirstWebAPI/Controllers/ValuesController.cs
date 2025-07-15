using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok(new[] { "value1", "value2" });

    [HttpPost]
    public IActionResult Post([FromBody] string value) => Ok($"Received: {value}");
}
