using Ardalis.Specification;

namespace DeviantPasswordManager.Core.IdentityAggregate.Specifications;

public class UserByIdentityIdSpec : Specification<User>
{
  public UserByIdentityIdSpec(string userId)
  {
    Query.Where(user => user.UserId == userId);
  }
}
