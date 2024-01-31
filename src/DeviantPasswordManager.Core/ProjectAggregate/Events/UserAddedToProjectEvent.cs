using Ardalis.SharedKernel;
using DeviantPasswordManager.Core.IdentityAggregate;

namespace DeviantPasswordManager.Core.ProjectAggregate.Events;

public class UserAddedToProjectEvent(User user, Project project) : DomainEventBase
{
  public User User { get; set; } = user;

  public Project Project { get; set; } = project;
}
