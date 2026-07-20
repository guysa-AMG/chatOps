
using chatOps.api.Models;


namespace chatOps.api;

public class Room
{
    public int roomId {get; set;}
    public required string name {get; set;}
    public required string author {get; set;}
    public ICollection<User> blacklisted{get;set;}=new List<User>();
    public ICollection<RoomUser> UsersRooms{get;set;}=new List<RoomUser>();
    public required ICollection<Tag> tags {get; set;}
    
}