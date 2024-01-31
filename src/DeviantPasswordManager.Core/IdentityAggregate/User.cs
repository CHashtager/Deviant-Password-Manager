using System.ComponentModel.DataAnnotations;
using Ardalis.SharedKernel;
using Microsoft.AspNetCore.Identity;

namespace DeviantPasswordManager.Core.IdentityAggregate;

public class User(string userId, string email, string passPhrase) : EntityBase, IAggregateRoot
{
  public string UserId { get; set; } = userId;
  public string Email { get; set; } = email;

  [Encrypted] public string PassPhrase { get; set; } = passPhrase;
}
