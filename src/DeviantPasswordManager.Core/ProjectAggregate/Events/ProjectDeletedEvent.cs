using Ardalis.SharedKernel;

namespace DeviantPasswordManager.Core.ProjectAggregate.Events;


internal sealed class ProjectDeletedEvent(int projectId) : DomainEventBase
{
  public int ProjectId { get; init; } = projectId;
}
