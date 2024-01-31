using Ardalis.SharedKernel;
using DeviantPasswordManager.Core.IdentityAggregate;
using DeviantPasswordManager.Core.ProjectAggregate;

namespace DeviantPasswordManager.Core.PasswordAggregate;

public class PasswordHistory(int passwordId, string encryptedPassword) : EntityBase, IAggregateRoot
{
  public int PasswordId { get; set; } = passwordId;
  public Password Password { get; set; } = default!;

  public string EncryptedPassword { get; set; } = encryptedPassword;

  public DateTime CreatedAt { get; set; } = DateTime.Now;
}
