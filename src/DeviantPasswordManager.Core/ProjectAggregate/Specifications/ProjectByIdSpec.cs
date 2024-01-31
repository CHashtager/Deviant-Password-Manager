using Ardalis.Specification;

namespace DeviantPasswordManager.Core.ProjectAggregate.Specifications;

public class ProjectByIdSpec : Specification<Project>
{
  public ProjectByIdSpec(int projectId, string adminId)
  {
    Query
      .Include(project => project.Admin)
      .Include(project => project.Members)
      .Where(project => project.Id == projectId && project.Admin.UserId == adminId);
  }
}
