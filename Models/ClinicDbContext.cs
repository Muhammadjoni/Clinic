using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Clinic.Models;
using Microsoft.EntityFrameworkCore;
using Clinic.Authentication;

namespace Clinic.Models
{
  public class ClinicDbContext : IdentityDbContext<AppUser>
  {
    public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options)
    {
    }

    public DbSet<Appointment> Appointment { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }
  }
}
