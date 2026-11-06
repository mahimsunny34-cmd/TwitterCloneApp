using TwitterClone.API.Data;
using TwitterClone.Application;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Services;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastratcure;
using TwitterClone.Infrastratcure.Repositories;

//register services
var builder = WebApplication.CreateBuilder(args);
//    builder.Services.AddControllers();
//builder.Services.AddSingleton<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IUserService, UserService>();

//builder.Services.AddSingleton<ITweetRepository, TweetRepository>();
//builder.Services.AddScoped<ITweetService, TweetService>();

//builder.Services.AddSingleton<IBookmarkRepository, BookmarksRepository>();
//builder.Services.AddScoped<IBookmarkService, BookmarkService>();

//builder.Services.AddSingleton<IRetweetRepository, RetweetRepository>();
//builder.Services.AddScoped<IRetweetService, RetweetService>();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

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


