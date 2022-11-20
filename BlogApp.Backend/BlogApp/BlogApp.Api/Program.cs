using BlogApp.Data;
using BlogApp.Data.Entities;
using BlogApp.Logic;
using BlogApp.Logic.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IDataLayer, DataLayer> ();
builder.Services.AddScoped<ILogicLayer, LogicLayer>();
builder.Services.AddScoped<ILogicService, LogicService>();

builder.Services.AddControllers()
    .AddJsonOptions(
    options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("DatabaseSettings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
