using Ardalis.Result;
using DeviantPasswordManager.Core.ProjectAggregate;
using DeviantPasswordManager.Core.ProjectAggregate.Events;
using DeviantPasswordManager.Core.Interfaces;
using Ardalis.SharedKernel;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DeviantPasswordManager.Core.Services;

public class DeleteProjectService(IRepository<Project> repository,
  IMediator mediator,
  ILogger<DeleteProjectService> logger) : IDeleteProjectService
{
  public async Task<Result> DeleteProject(int projectId)
  {
    logger.LogInformation("Deleting Project {projectId}", projectId);
    var aggregateToDelete = await repository.GetByIdAsync(projectId);
    if (aggregateToDelete == null) return Result.NotFound();

    await repository.DeleteAsync(aggregateToDelete);
    var domainEvent = new ProjectDeletedEvent(projectId);
    await mediator.Publish(domainEvent);
    return Result.Success();
  }
}
