using Ardalis.Result;
using Ardalis.SharedKernel;
using DeviantPasswordManager.Core.IdentityAggregate;
using DeviantPasswordManager.Core.Interfaces;
using DeviantPasswordManager.Core.ProjectAggregate;
using DeviantPasswordManager.Core.ProjectAggregate.Specifications;

namespace DeviantPasswordManager.UseCases.Projects.List;

public class ListProjectsHandler(IReadRepository<Project> projectRepository, ICurrentUserService currentUserService) : IQueryHandler<ListProjectsQuery, Result<List<ProjectDto>>>
{
  public async Task<Result<List<ProjectDto>>> Handle(ListProjectsQuery request, CancellationToken cancellationToken)
  {
    var spec = new ProjectsByUserIdSpec(currentUserService.UserId);
    var projects = await projectRepository.ListAsync(spec, cancellationToken);
    return Result.Success(projects.Select(p => new ProjectDto(p.Id, p.Name)).ToList());
  }
}
