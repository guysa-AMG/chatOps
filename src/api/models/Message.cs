

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Message
{
    
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id {get;set;}

    public required string Name{get;set;}
    public required string Data{get;set;}
    public DateTime Time{get;set;}

    public List<string>? Attachments{get;set;}

}