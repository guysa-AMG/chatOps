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

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(conStr).UseSnakeCaseNamingConvention());
builder.Services.AddSingleton<IMongoClient>(options => new MongoClient(mongocli));
builder.WebHost.UseUrls("http://0.0.0.0:5000");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
