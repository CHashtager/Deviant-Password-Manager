using DeviantPasswordManager.Core.IdentityAggregate;
using DeviantPasswordManager.Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DeviantPasswordManager.Infrastructure.Data;

public static class SeedData
{
  public static readonly User User1 = new (Guid.Empty.ToString(), "test@email.com", "secret");
  
  public static readonly Project Project1 = new("Ardalis", 1);
  public static readonly Project Project2 = new("Snowfrog", 1);

  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
    {
      if (dbContext.Users.Any())
      {
        return;
      }

      PopulateTestData(dbContext);
    }
  }
  public static void PopulateTestData(AppDbContext dbContext)
  {
    foreach (var item in dbContext.Users)
    {
      dbContext.Remove(item);
    }
    dbContext.SaveChanges();

    dbContext.Users.Add(User1);
    
    foreach (var item in dbContext.Projects)
    {
      dbContext.Remove(item);
    }
    dbContext.SaveChanges();

    dbContext.Projects.Add(Project1);
    dbContext.Projects.Add(Project2);

    dbContext.SaveChanges();
  }
}
