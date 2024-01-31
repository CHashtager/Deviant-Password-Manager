using Ardalis.Result;
using Ardalis.SharedKernel;
using DeviantPasswordManager.Core.Exceptions;
using DeviantPasswordManager.Core.IdentityAggregate;
using DeviantPasswordManager.Core.IdentityAggregate.Specifications;
using DeviantPasswordManager.Core.Interfaces;
using DeviantPasswordManager.Core.ProjectAggregate;
using DeviantPasswordManager.Core.ProjectAggregate.Specifications;

namespace DeviantPasswordManager.UseCases.Projects.Update;

public class UpdateProjectHandler
  (IRepository<Project> repository, ICurrentUserService currentUserService) : ICommandHandler<UpdateProjectCommand,
    Result>
{
  public async Task<Result> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
  {
    var projectSpec = new ProjectByIdSpec(request.Id, currentUserService.UserId);
    var project = await repository.FirstOrDefaultAsync(projectSpec, cancellationToken);
    if (project is null) return Result.NotFound("Project not found");

    project.UpdateName(request.Name);
    await repository.UpdateAsync(project, cancellationToken);

    return Result.Success();
  }
}
