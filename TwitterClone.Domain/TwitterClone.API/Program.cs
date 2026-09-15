using TwitterClone.Domain.Entities;

//register services
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();



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


