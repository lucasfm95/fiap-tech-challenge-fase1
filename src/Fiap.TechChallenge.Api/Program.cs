using Fiap.TechChallenge.Api;
using Fiap.TechChallenge.Api.Configurations;
using Fiap.TechChallenge.Api.Middlewares;
using Fiap.TechChallenge.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ContactDbContext>(options =>
{
    options.UseNpgsql(Environment.GetEnvironmentVariable("CONNECTION_STRING_DB_POSTGRES"));
});

builder.Services.RegisterApplicationServices();
builder.Services.RegisterRepositories();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.UseHealthcheck();
app.UseMiddleware<ExceptionMiddleware>();
app.Run();