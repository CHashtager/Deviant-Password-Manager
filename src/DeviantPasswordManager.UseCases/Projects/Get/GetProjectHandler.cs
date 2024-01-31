using Ardalis.Result;
using Ardalis.SharedKernel;
using DeviantPasswordManager.Core.Exceptions;
using DeviantPasswordManager.Core.IdentityAggregate;
using DeviantPasswordManager.Core.Interfaces;
using DeviantPasswordManager.Core.ProjectAggregate;
using DeviantPasswordManager.Core.ProjectAggregate.Specifications;
using Microsoft.AspNetCore.Identity;

namespace DeviantPasswordManager.UseCases.Projects.Get;

public class GetProjectHandler(IReadRepository<Project> projectRepository, ICurrentUserService currentUserService)
  : IQueryHandler<GetProjectQuery, Result<ProjectWithMembersDto>>
{
  public async Task<Result<ProjectWithMembersDto>> Handle(GetProjectQuery request, CancellationToken cancellationToken)
  {
    var spec = new ProjectByIdSpec(request.ProjectId, currentUserService.UserId);
    var project = await projectRepository.FirstOrDefaultAsync(spec, cancellationToken);

    if (project is null) return Result.NotFound();

    var members = project.Members.Select(user => new ProjectMemberDto(user.Email)).ToList();

    return Result.Success(new ProjectWithMembersDto(project.Id, project.Name, members));
  }
}
