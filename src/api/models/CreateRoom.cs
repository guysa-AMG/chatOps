


public class CreateRoom
{
    public String CUID {get; set;}=String.Empty;//Creators User Identification
    public String AUID{get; set;}=String.Empty; //Admin User Identification
    public String Name{get; set;}=String.Empty;//Room Name
    public String? Description{get; set;}//Room Description

    public List<Tag> Tags{get; set;}=[];


    
}