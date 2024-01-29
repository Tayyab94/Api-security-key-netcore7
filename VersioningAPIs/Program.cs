using Asp.Versioning;
using Microsoft.Extensions.Options;
using VersioningAPIs.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.AddRinLogger();
builder.Services.AddRin();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IStudentRepo,StudentRepo>();
builder.Services.AddApiVersioning(op =>
{
    op.AssumeDefaultVersionWhenUnspecified = true;
    op.DefaultApiVersion = ApiVersion.Default; //new ApiVersion(1,0)
    op.ReportApiVersions = true;
    op.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("api-version"),
        new UrlSegmentApiVersionReader()
        );
}).AddApiExplorer(opt =>
{
    opt.GroupNameFormat = "'v'V";
    opt.SubstituteApiVersionInUrl = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseRin();
    app.UseSwagger();
    //app.UseSwaggerUI();

    app.UseSwaggerUI(c =>
    {

        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "API v2");
    });
    app.UseRinDiagnosticsHandler();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
