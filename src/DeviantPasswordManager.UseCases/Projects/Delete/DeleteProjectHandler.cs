using Ardalis.Result;
using Ardalis.SharedKernel;
using DeviantPasswordManager.Core.Exceptions;
using DeviantPasswordManager.Core.Interfaces;
using DeviantPasswordManager.Core.ProjectAggregate;
using DeviantPasswordManager.Core.ProjectAggregate.Specifications;

namespace DeviantPasswordManager.UseCases.Projects.Delete;

public class DeleteProjectHandler(IDeleteProjectService deleteProjectService, ICurrentUserService currentUserService, IReadRepository<Project> projectRepository)
  : ICommandHandler<DeleteProjectCommand, Result>
{
  public async Task<Result> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
  {
    var project = await projectRepository.FirstOrDefaultAsync(new ProjectByIdSpec(request.ProjectId, currentUserService.UserId), cancellationToken);

    if (project is null) return Result.NotFound("Project not found.");
    
    return await deleteProjectService.DeleteProject(request.ProjectId);
  }
}
