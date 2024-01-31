using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using DeviantPasswordManager.Core.IdentityAggregate;
using DeviantPasswordManager.Core.ProjectAggregate;

namespace DeviantPasswordManager.Core.PasswordAggregate;

public class Password
  (string name, string username, string encryptedPassword, string url, int projectId, int userId) : EntityBase,
    IAggregateRoot
{
  [Encrypted]
  public string Name { get; set; } = name;
  [Encrypted]
  public string Username { get; set; } = username;
  public string EncryptedPassword { get; set; } = encryptedPassword;
  [Encrypted]
  public string Url { get; set; } = url;

  public int ProjectId { get; set; } = projectId;
  public Project Project { get; set; } = default!;

  public int UserId { get; set; } = userId;
  public User User { get; set; } = default!;
  
  public void UpdateProperties(string newName, string newUsername, string newUrl)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
    Username = Guard.Against.NullOrEmpty(newUsername, nameof(newUsername));
    Url = Guard.Against.NullOrEmpty(newUrl, nameof(newUrl));
  }
}
