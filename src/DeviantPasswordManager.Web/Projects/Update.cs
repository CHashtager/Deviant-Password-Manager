using Ardalis.Result;
using DeviantPasswordManager.UseCases.Projects.Update;
using FastEndpoints;
using MediatR;

namespace DeviantPasswordManager.Web.Projects;

public class Update(IMediator mediator) : Endpoint<UpdateProjectRequest>
{
  public override void Configure()
  {
    Put(UpdateProjectRequest.Route);
    // AllowAnonymous();
  }

  public override async Task HandleAsync(
    UpdateProjectRequest request,
    CancellationToken cancellationToken)
  {
    var command = new UpdateProjectCommand(request.ProjectId, request.Name);

    var result = await mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendAsync(result.Errors.FirstOrDefault()!, 404, cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      await SendNoContentAsync(cancellationToken);
    }
  }
}
