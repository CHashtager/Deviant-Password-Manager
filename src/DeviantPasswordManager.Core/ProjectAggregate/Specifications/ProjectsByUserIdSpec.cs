using Ardalis.Specification;

namespace DeviantPasswordManager.Core.ProjectAggregate.Specifications;

public class ProjectsByUserIdSpec : Specification<Project>
{
  public ProjectsByUserIdSpec(string adminId, int? parentId)
  {
    Query.Include(q => q.Admin).Where(project => project.Admin.UserId == adminId && 
                                                 (!parentId.HasValue || project.ParentId == parentId.Value)
                                                 );
  }
}
