using chatOps.api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace chatOps.api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RoomsController : ControllerBase
{
    readonly AppDbContext _appDbContext;
    public RoomsController(AppDbContext context)
    {
        _appDbContext = context;
    }
    [HttpGet("List")]
    public String Get()
    {

        return _appDbContext.Rooms.First().ToJson();

    }
    [HttpGet("tags/list")]
    public IActionResult STag()
    {
        return Ok("still yet To implement");
    }

    [HttpPost("create")]
    public async Task<IActionResult> ppat([FromBody] CreateRoom data)
    {
      bool successful = await _appDbContext.NewRoom(data);
      if (successful){  return Created();   }
      else{ return StatusCode(500);}
    }
   
   
}