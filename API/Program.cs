using API.Configurations;
using Application.Inrefaces;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureLogger()
       .AddApplication()
       .AddPersistence()
       .AddInfrastructure()
       .ConfigureAPI()
       .AddAutoMapper();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
