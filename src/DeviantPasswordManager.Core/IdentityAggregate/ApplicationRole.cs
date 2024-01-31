using Ardalis.SharedKernel;
using Microsoft.AspNetCore.Identity;

namespace DeviantPasswordManager.Core.IdentityAggregate;

public class ApplicationRole : IdentityRole<string>, IAggregateRoot
{
  public bool IsActive { get; set; } = true;

  public string Description { get; set; } = default!;
}
