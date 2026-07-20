using chatOps.api.Models;
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
        _appDbContext=context; 
    }
     [HttpGet("List")]
    public String Get()
    {
        
     return _appDbContext.Users.First().ToJson();
                    
    }
}