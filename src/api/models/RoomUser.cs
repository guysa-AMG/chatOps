


using chatOps.api;
using chatOps.api.Models;

public class RoomUser
{
    public int Id { get; set; }
    public int roomId { get; set; }
    public Room Room { get; set; } = null!;

    public int userId { get; set; }
    public User User { get; set; } = null!;

    public DateTime joinedAt { get; set; } = DateTime.UtcNow;
}