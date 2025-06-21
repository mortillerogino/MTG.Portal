using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MTG.Application.Services;
using MTG.Application.Services.Interfaces;
using MTG.Database.DBContexts;
using MTG.Database.UnitOfWork;
using MTG.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
   .SetBasePath(Directory.GetCurrentDirectory())
   .AddJsonFile("appsettings.json", optional: true)
   .AddUserSecrets<Program>()
   .AddEnvironmentVariables();

// Add logging  
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container  
builder.Services.AddLogging(); 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle  
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork>();
builder.Services.AddScoped<IBinderService, BinderService>();
builder.Services.AddScoped<IMtgCardService, MtgCardService>();

builder.Services.AddAutoMapper(Assembly.Load("MTG.Application"));

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
