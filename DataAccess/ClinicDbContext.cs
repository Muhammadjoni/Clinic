using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Clinic.Authentication;
using Clinic.Models;
using Microsoft.Extensions.Configuration;

namespace Clinic.DataAccess
{
  public class ClinicDbContext : IdentityDbContext<AppUser>
  {
    private IConfigurationRoot _config;
    public ClinicDbContext(IConfigurationRoot config, DbContextOptions<ClinicDbContext> options) : base(options)
    {
        _config = config;
    }

    public DbSet<User> User { get; set; }
    public DbSet<Appointment> Appointment { get; set; }

    // protected override void OnModelCreating(ModelBuilder builder)
    // {
    //   base.OnModelCreating(builder);
    // }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseSqlServer(_config["ConnectionStrings:ClinicConnection"]);//connection string get by appsetting.json
    }
  }
}
