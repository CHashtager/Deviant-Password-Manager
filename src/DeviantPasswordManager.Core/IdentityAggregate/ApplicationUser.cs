using Ardalis.SharedKernel;
using Microsoft.AspNetCore.Identity;

namespace DeviantPasswordManager.Core.IdentityAggregate;

public class ApplicationUser : IdentityUser<string>, IAggregateRoot
{
  public bool IsActive { get; set; } = true;

  public DateTimeOffset? LastLoginDate { get; set; }
}
