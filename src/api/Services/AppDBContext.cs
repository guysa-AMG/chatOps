using Microsoft.EntityFrameworkCore;

namespace chatOps.api.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Tag> Tags {get; set;}

    public async Task<bool> NewRoom(CreateRoom roomRequest)
    {
        try{
        Room room = Room.FromRequest(roomRequest);
        await this.Rooms.AddAsync(room);
        await this.SaveChangesAsync();
        return true;
        }catch(Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
        

    }
  
}