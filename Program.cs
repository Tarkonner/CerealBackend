using Microsoft.EntityFrameworkCore;
using Test.DataContext;

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Generates the OpenAPI JSON document
    app.UseSwaggerUI(); // Serves the Swagger UI for visual feedback
}

app.UseHttpsRedirection();

app.MapControllers();

await app.RunAsync();