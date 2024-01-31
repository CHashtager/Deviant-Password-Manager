using System.Reflection;
using DeviantPasswordManager.Core.IdentityAggregate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DeviantPasswordManager.Infrastructure.Identity;

public class AppIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
  public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
    : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    modelBuilder.Entity<ApplicationUser>().Property(e => e.Id).ValueGeneratedOnAdd();
    modelBuilder.Entity<ApplicationRole>().Property(e => e.Id).ValueGeneratedOnAdd();
  }
}
