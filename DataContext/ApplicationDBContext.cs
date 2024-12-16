using Microsoft.EntityFrameworkCore;
using Test.Dtos;
using Test.Models;

namespace Test.DataContext;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) 
        : base(options)
    {
    }
    
    public DbSet<Cereal> Cereals { get; set; }
    public DbSet<Image> Images { get; set; }
}