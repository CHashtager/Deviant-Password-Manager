using Ardalis.Specification;

namespace DeviantPasswordManager.Core.PasswordAggregate.Specifications;

public class PasswordAuthedSpec : Specification<Password>
{
  public PasswordAuthedSpec(int passwordId, int projectId, string userId)
  {
    Query
      .Include(password => password.User)
      .Where(password => password.Id == passwordId &&
                         password.ProjectId == projectId &&
                         password.User.UserId == userId);
  }
}
