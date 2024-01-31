using System.Reflection;
using Ardalis.SharedKernel;
using DeviantPasswordManager.Core.IdentityAggregate;
using DeviantPasswordManager.Core.PasswordAggregate;
using DeviantPasswordManager.Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DataEncryption;
using Microsoft.EntityFrameworkCore.DataEncryption.Providers;

namespace DeviantPasswordManager.Infrastructure.Data;

public class AppDbContext : DbContext
{
  private readonly IDomainEventDispatcher? _dispatcher;
  readonly byte[] _encryptionKey = Convert.FromBase64String("+S/JiSw+9Y3a/7yYNv1t2JHxvys7E0tmtCXD8MjnM5w=");
  readonly byte[] _encryptionIv = Convert.FromBase64String("e74q9WJmowLLUm1Av9DHkA==");
  private readonly IEncryptionProvider _provider;

  public AppDbContext(DbContextOptions<AppDbContext> options,
    IDomainEventDispatcher? dispatcher)
    : base(options)
  {
    _dispatcher = dispatcher;
    _provider = new AesProvider(_encryptionKey, _encryptionIv,padding:System.Security.Cryptography.PaddingMode.Zeros);
  }

  public DbSet<Password> Passwords => Set<Password>();
  public DbSet<Project> Projects => Set<Project>();
  public DbSet<User> Users => Set<User>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.UseEncryption(_provider);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    // ignore events if no dispatcher provided
    if (_dispatcher == null) return result;

    // dispatch events only if save was successful
    var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
      .Select(e => e.Entity)
      .Where(e => e.DomainEvents.Any())
      .ToArray();

    await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

    return result;
  }

  public override int SaveChanges()
  {
    return SaveChangesAsync().GetAwaiter().GetResult();
  }
}
