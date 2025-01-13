using Microsoft.EntityFrameworkCore;
using Test.Dtos;
using Test.Models;

namespace Test.DataContext;

// Defines the application's database context, used for interacting with the database
public class ApplicationDBContext : DbContext
{
    // Constructor to initialize the DbContext with the provided options
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) 
        : base(options)
    {
    }
    
    // Represents the "Cereals" table in the database
    public DbSet<Cereal> Cereals { get; set; }

    // Represents the "Images" table in the database
    public DbSet<Image> Images { get; set; }
}