


using chatOps.api;

public class Tag
{
    public int Id{get; set;}
    public required String Name{get; set;}
    public String Colour{get; set;}="#ffffff";
    public required String Description{get; set;}

    public List<Room> Rooms{get; set;}=[];
}