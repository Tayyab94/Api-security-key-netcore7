using FormulaOne.API.Authentication;
using FormulaOne.API.Configurations;
using FormulaOne.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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
builder.Services.AddSwaggerGen(s =>
{
    
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });

    s.AddSecurityDefinition("Apikey", new OpenApiSecurityScheme
    {
        Description = "Api Key to Secure the APIs",
        Type = SecuritySchemeType.ApiKey,
        Name = AuthConfig.ApikeyHeader,
        In = ParameterLocation.Header,
        Scheme = "ApikeyScheme"
    });

    //s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    //{
    //    In = ParameterLocation.Header,
    //    Description = "Please enter token",
    //    Name = "Authorization",
    //    Type = SecuritySchemeType.Http,
    //    BearerFormat = "JWT",
    //    Scheme = "bearer"
    //});
    var securityRequirement = new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Apikey"
                }
            },
            new List<string>()
        },
        //{
        //    new OpenApiSecurityScheme
        //    {
        //        Reference = new OpenApiReference
        //        {
        //            Type = ReferenceType.SecurityScheme,
        //            Id = "Bearer"
        //        }
        //    },
        //    new List<string>()
        //}
    };

    s.AddSecurityRequirement(securityRequirement);
 

    //s.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    //s.AddSecurityDefinition("Apikey", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    //{
    //    Description = "Api Key to Secure the APIs",
    //    Type = SecuritySchemeType.ApiKey,
    //    Name = AuthConfig.ApikeyHeader,
    //    In = ParameterLocation.Header,
    //    Scheme = "ApikeyScheme"
    //});

    //var scheme = new OpenApiSecurityScheme()
    //{
    //    Reference = new OpenApiReference()
    //    {
    //        Type = ReferenceType.SecurityScheme,
    //        Id = "Apikey"
    //    },
    //    In = ParameterLocation.Header,
    //};

    //var requirement = new OpenApiSecurityRequirement()
    //{
    //    {scheme, new List<string>() }
    //};

    //s.AddSecurityRequirement(requirement);
});
builder.Services.AddScoped<ApikeyAuthenticationFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//if we want to use Authentication Apikey as an Action filter then this middleware should be comment
// Middleware to check, Valid api-key or not.. 
//app.UseMiddleware<ApikeyMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
