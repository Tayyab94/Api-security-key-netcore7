using FormulaOne.API.Authentication;
using FormulaOne.API.Configurations;
using FormulaOne.API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// This help us to bind the section of the .json file 
var dbConfig = new DatabaseConfig();
builder.Configuration.GetSection("DatabaseConfig").Bind(dbConfig);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(connectionString, action =>
    {
        action.CommandTimeout(dbConfig.TimeoutTime);
    });
    options.EnableDetailedErrors(dbConfig.DetailedError);
    options.EnableSensitiveDataLogging(dbConfig.SensitiveDataLogging);
});

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


// Middleware to check, Valid api-key or not.. 
app.UseMiddleware<ApikeyMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
