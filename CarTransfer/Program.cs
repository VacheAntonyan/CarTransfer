using CarTransfer;
using CarTransfer.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<Datacontext>();
//builder.Services.AddSingleton<IRepasitory<Car, int>, Repository<Car, int>>();
//builder.Services.AddSingleton<IRepasitory<Transfers, int>, Repository<Transfers, int>>();
builder.Services.AddScoped<DbContext, Datacontext>();
builder.Services.AddScoped<IRepasitory<Car, int>, Repository<Car, int>>();
builder.Services.AddScoped<IRepasitory<Transfers, int>, Repository<Transfers, int>>();

//builder.Services.AddScoped<UserService>();  // Register your custom user service
//builder.Services.AddControllers();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.MapControllers();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
