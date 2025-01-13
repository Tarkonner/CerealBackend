using Microsoft.EntityFrameworkCore;
using Test.DataContext;
using Test.Interfaces;
using Test.Models;
using Test.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Required if you plan to use controllers in the future
builder.Services.AddEndpointsApiExplorer(); // Enables endpoint discovery for Swagger
builder.Services.AddSwaggerGen(); // Adds Swagger generator

//Connect to MySQL
builder.Services.AddDbContext<ApplicationDBContext>((serviceProvider, options) =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("MySqlConnection");
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 36)));
});

// Configure CORS (Cross-Origin Resource Sharing)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()    // Allows requests from any origin
            .AllowAnyMethod()       // Allows any HTTP method (GET, POST, etc.)
            .AllowAnyHeader();      // Allows any headers in the request
    });
});

// Add application-specific components (Dependency Injection)
builder.Services.AddScoped<ICerealRepository, CerealRepositry>();
builder.Services.AddScoped<IImageRepository, CerealImageRepositry>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Generates the OpenAPI JSON document
    app.UseSwaggerUI(); // Serves the Swagger UI for visual feedback
}

app.UseCors("AllowAll");    // Applies the configured CORS policy
app.UseHttpsRedirection();  // Enforces HTTPS for all requests
app.MapControllers();       // Maps controller endpoints to the request pipeline

await app.RunAsync();