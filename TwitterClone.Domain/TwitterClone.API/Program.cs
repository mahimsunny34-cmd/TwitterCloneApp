using TwitterClone.API.Data;
using TwitterClone.Domain.Entities;

//register services
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<TweetRepository>();
builder.Services.AddSingleton<UserRepository>();



// Configure the HTTP request pipeline.
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//middlewares
app.UseHttpsRedirection();

app.UseAuthorization();

//map controllers
app.MapControllers();

app.Run();


