using Microsoft.EntityFrameworkCore;

namespace F1API.Models
{
  public class F1Context : DbContext
  {
    public F1Context(DbContextOptions<F1Context> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
  builder.Entity<Driver>()
      .HasData(
        new Driver { DriverId = 1, Name = "Lewis Hamilton", Age = 37, Team = "Mercedes" },
        new Driver { DriverId = 2, Name = "Max Verstappen", Age = 24, Team = "Red Bull" },
        new Driver { DriverId = 3, Name = "Daniel Ricciardo", Age = 32, Team = "McLaren" },
        new Driver { DriverId = 4, Name = "Carlos Sainz", Age = 27, Team = "Ferrari" },
        new Driver { DriverId = 5, Name = "Sebastian Vettel", Age = 34, Team = "Astin Martin" }
      );
    }
    public DbSet<Driver> Drivers { get; set; }
  }
}