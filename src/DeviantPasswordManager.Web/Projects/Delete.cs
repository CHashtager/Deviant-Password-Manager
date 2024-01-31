using FastEndpoints;
using Ardalis.Result;
using MediatR;
using DeviantPasswordManager.UseCases.Projects.Delete;

namespace DeviantPasswordManager.Web.Projects;

public class Delete(IMediator mediator)
  : Endpoint<DeleteProjectRequest>
{
  public override void Configure()
  {
    Delete(DeleteProjectRequest.Route);
  }

  public override async Task HandleAsync(
    DeleteProjectRequest request,
    CancellationToken cancellationToken)
  {
    var command = new DeleteProjectCommand(request.ProjectId);

    var result = await mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      await SendNoContentAsync(cancellationToken);
    };
  }
}
