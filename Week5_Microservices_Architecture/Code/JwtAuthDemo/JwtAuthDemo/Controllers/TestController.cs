using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [Authorize]
    [HttpGet("secure")]
    public IActionResult GetSecureData()
    {
        return Ok(new { message = "✅ You accessed a protected endpoint successfully!" });
    }
}
