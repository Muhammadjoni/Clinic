using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Authentication
{
  public class ClinicDbContext : IdentityDbContext<ClinicUser>
  {
    public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }
  }
}
