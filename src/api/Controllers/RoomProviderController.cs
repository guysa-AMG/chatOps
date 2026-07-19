using Microsoft.AspNetCore.Mvc;

namespace chatOps.api.Controllers;

[ApiController]
[Route("api/list")]
public class RoomProviderController : ControllerBase
{
    // [HttpGet(Name = "List")]
    public string Get()
    {
        return "hello";
    }
}