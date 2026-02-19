using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers;

[ApiController]
[Route("api/cs/[controller]")]
public class PlatformsController : ControllerBase
{
    [HttpPost]
    public ActionResult TestInboundConnection()
    {
        Console.WriteLine("--> Inbound POST | Command Service");
        return Ok();
    }
}