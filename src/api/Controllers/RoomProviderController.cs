using Microsoft.AspNetCore.Mvc;

namespace chatOps.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomProviderController : ControllerBase
{
    [HttpGet(Name = "List")]
    public string Get()
    {
        return "hello";
    }
}