using Ardalis.Specification;

namespace DeviantPasswordManager.Core.IdentityAggregate.Specifications;

public class UserByEmailSpec : Specification<User>
{
  public UserByEmailSpec(string email)
  {
    Query.Where(user => user.Email == email.ToUpper());
  }
}
