using Ardalis.SharedKernel;

namespace DeviantPasswordManager.Core.PasswordAggregate.Events;

internal sealed class PasswordDeletedEvent(int passwordId) : DomainEventBase
{
  public int PasswordId { get; init; } = passwordId;
}
