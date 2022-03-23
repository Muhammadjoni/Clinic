using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Clinic.Authentication;
using Clinic.Models;

namespace Clinic.DataAccess
{
  public class ClinicDbContext : IdentityDbContext<AppUser>
  {
    public ClinicDbContext(DbContextOptions<ClinicDbContext> context) : base(context)
    {
    }

    public DbSet<User> User { get; set; }
    public DbSet<Appointment> Appointment { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }
  }
}
