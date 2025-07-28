using Microsoft.EntityFrameworkCore;
using Serilog;
using TheEasyBazar.API.Extensions;
using TheEasyBazar.API.Middlewares;
using TheEasyBazar.Data.DbContexts;
using TheEasyBazar.Data.IRepositories;
using TheEasyBazar.Data.Repositories;
using TheEasyBazar.Service.Interfaces;
using TheEasyBazar.Service.Mappers;
using TheEasyBazar.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Database configuration
builder.Services.AddDbContext<AppDbContext>(option
    => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddCustomService();
builder.Services.AddAutoMapper(typeof(MappingProfile));

//Logger
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

//Middleware
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlerMiddleWare>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();