
using chatOps.api.Models;


namespace chatOps.api;

public class Room
{
    public int roomId { get; set; }
    public required string name { get; set; }=String.Empty;
     public required string creator { get; set; }=String.Empty;

     public required DateTime created { get; set; }
    public required string author { get; set; }=String.Empty;
    public ICollection<User> blacklisted { get; set; } = new List<User>();
    public ICollection<RoomUser> UsersRooms { get; set; } = new List<RoomUser>();
    public required List<Tag> Tags { get; set; }= new();

   public static Room FromRequest(CreateRoom req)
    {  

        return new Room{name= req.Name,
                        created=DateTime.UtcNow,
                        creator=req.CUID,
                        author= req.AUID,
                        Tags= req.Tags};
    }

}