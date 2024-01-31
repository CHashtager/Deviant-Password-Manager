using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using DeviantPasswordManager.Core.IdentityAggregate;
using DeviantPasswordManager.Core.ProjectAggregate.Events;

namespace DeviantPasswordManager.Core.ProjectAggregate;

public class Project(string name, int adminId) : EntityBase, IAggregateRoot
{
  public string Name { get; private set; } = name;

  public User Admin { get; set; } = default!;
  public int AdminId { get; set; } = adminId;

  public ICollection<User> Members { get; set; } = new List<User>();

  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }

  public void AddUser(User user)
  {
    Guard.Against.Null(user, nameof(user));
    Members.Add(user);

    var userAddedToProjectEvent = new UserAddedToProjectEvent(user: user, project: this);
    base.RegisterDomainEvent(userAddedToProjectEvent);
  }
  
  public void RemoveUser(User user)
  {
    Guard.Against.Null(user, nameof(user));
    Members.Remove(user);

    var userRemovedFromProjectEvent = new UserRemovedFromProjectEvent(user: user, project: this);
    base.RegisterDomainEvent(userRemovedFromProjectEvent);
  }
}
