using Ardalis.Specification;

namespace DeviantPasswordManager.Core.PasswordAggregate.Specifications;

public class PasswordsByProjectIdSpec : Specification<Password>
{
  public PasswordsByProjectIdSpec(int projectId, string userId)
  {
    Query
      .Include(password => password.Project)
      .ThenInclude(project => project.Members)
      .Include(password => password.User)
      .Where(password => password.ProjectId == projectId &&
                         (password.User.UserId == userId ||
                          password.Project.Members.Any(member => member.UserId == userId)));
  }
}
