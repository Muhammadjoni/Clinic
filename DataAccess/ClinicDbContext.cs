using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Clinic.Models;
using Microsoft.EntityFrameworkCore;


namespace Clinic.DataAccess
{
  public class ClinicDbContext : IdentityDbContext<User>
  {
    public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options)
    {
    }

    public DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }

    public override int SaveChanges()
    {
      ChangeTracker.DetectChanges();
      return base.SaveChanges();
    }
  }
}
