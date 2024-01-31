using Ardalis.Specification;

namespace DeviantPasswordManager.Core.ProjectAggregate.Specifications;

public class ProjectsByUserIdSpec : Specification<Project>
{
  public ProjectsByUserIdSpec(string adminId)
  {
    Query.Include(q => q.Admin).Where(project => project.Admin.UserId == adminId);
  }
}
