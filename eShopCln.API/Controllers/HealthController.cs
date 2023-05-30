using Microsoft.AspNetCore.Mvc;

namespace eShopCln.API.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Healthy()
    {
        return Ok("Healthy");
    }
}
