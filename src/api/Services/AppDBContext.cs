using Microsoft.EntityFrameworkCore;

namespace chatOps.api.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    public DbSet<User> Users {get; set;}
    public DbSet<Room> Rooms {get; set;}


}