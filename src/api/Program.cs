using chatOps.api.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

string conStr = builder.Configuration.GetConnectionString("postgres")!;
string mongocli = builder.Configuration.GetConnectionString("mongoDb")!;
builder.Services.AddCors(options =>
    options.AddPolicy("AllowAll",policy=>
        policy.WithOrigins("https://teughly-unexcavated-kaitlynn.ngrok-free.dev","https://client-chat-application.vercel.app")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials()
            )
    );
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(conStr).UseSnakeCaseNamingConvention());
builder.Services.AddSingleton<IMongoClient>(options =>
 new MongoClient(mongocli));

builder.Services.AddSingleton(options => options.GetRequiredService<IMongoClient>().GetDatabase("chatops"));

builder.Services.AddSignalR();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCors("AllowAll");
app.MapHub<ChatOpsHub>("/chatops");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
