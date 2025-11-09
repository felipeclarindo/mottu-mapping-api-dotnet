using Microsoft.EntityFrameworkCore;
using MotoMappingApiDotnet.Src.Infra.Database;
using MotoMappingApiDotnet.Src.Utils.Functions;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var helper = new HelperFunctions();
helper.LoadEnvFromRoot();

var builder = WebApplication.CreateBuilder(args);

// Detecta ambiente
var environment = builder.Environment.EnvironmentName;

// ✅ Adiciona API Versioning (caso use controllers versionados)
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap["apiVersion"] = typeof(ApiVersionRouteConstraint);
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

// ✅ Somente conecta ao banco se NÃO estiver em Testing
if (environment != "Testing")
{
    var connectionString = builder.Configuration.GetConnectionString("ORACLE_DB")
        ?? throw new InvalidOperationException("Connection string 'ORACLE_DB' not found.");

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseOracle(connectionString));
}

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Healthchecks
builder.Services.AddHealthChecks();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ✅ Map antes dos controllers
app.MapHealthChecks("/health");

app.UseCors("AllowAllOrigins");
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();

public partial class Program { }
