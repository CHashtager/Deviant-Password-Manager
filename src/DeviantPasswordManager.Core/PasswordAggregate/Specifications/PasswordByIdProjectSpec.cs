using Ardalis.Specification;

namespace DeviantPasswordManager.Core.PasswordAggregate.Specifications;

public class PasswordByIdProjectSpec : Specification<Password>
{
  public PasswordByIdProjectSpec(int passwordId, int projectId, string userId)
  {
    Query
      .Include(password => password.User)
      .Include(password => password.Project)
      .ThenInclude(project => project.Members)
      .Where(password => password.Id == passwordId && password.ProjectId == projectId &&
        password.User.UserId == userId || password.Project.Members.Any(u => u.UserId == userId));
  }
}
