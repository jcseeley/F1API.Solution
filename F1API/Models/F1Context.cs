using Microsoft.EntityFrameworkCore;

namespace F1API.Models
{
  public class F1Context : DbContext
  {
    public F1Context(DbContextOptions<F1Context> options)
        : base(options)
    {
    }

    public DbSet<Driver> Drivers { get; set; }
  }
}