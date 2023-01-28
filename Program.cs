using Microsoft.EntityFrameworkCore;
using samaranipi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MyAppContext>(opt =>
    opt.UseSqlite("Data Source=contracts.db"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build(); // в гитигонор бд, .vscode и bin?

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contracts}/{action=Import}");

app.MapControllerRoute(
    name: "1",
    pattern: "api/{controller}/{action}");    

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
