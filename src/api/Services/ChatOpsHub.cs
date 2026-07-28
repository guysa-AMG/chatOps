



using Microsoft.AspNetCore.SignalR;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;

public class ChatOpsHub : Hub
{
    private readonly IMongoCollection<Message> collection;

   public ChatOpsHub(IMongoDatabase database)
    {
          collection =  database.GetCollection<Message>("chats");
    }
    
    public async Task SendMessage(String name,String Message)
    {
        var message = new Message{Data=Message,Name=name};
       await collection.InsertOneAsync(message);
       await this.Clients.All.SendAsync("ReceiveMessage",name,Message);
    }
}