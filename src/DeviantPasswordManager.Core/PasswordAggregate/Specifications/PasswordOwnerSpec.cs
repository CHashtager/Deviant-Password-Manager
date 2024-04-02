using Ardalis.Specification;

namespace DeviantPasswordManager.Core.PasswordAggregate.Specifications;

public class PasswordOwnerSpec : Specification<Password>
{
  public PasswordOwnerSpec(int passwordId, string userId)
  {
    Query
      .Include(password => password.User)
      .Where(password => password.Id == passwordId &&
                         password.User.UserId == userId);
  }
}
