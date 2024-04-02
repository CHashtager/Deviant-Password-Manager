using Ardalis.Result;
using DeviantPasswordManager.UseCases.Projects.Update;
using FastEndpoints;
using MediatR;

namespace DeviantPasswordManager.Web.Projects;

public class Update(IMediator mediator) : Endpoint<UpdateProjectRequest, UpdateProjectResponse>
{
  public override void Configure()
  {
    Put(UpdateProjectRequest.Route);
  }

  public override async Task HandleAsync(
    UpdateProjectRequest request,
    CancellationToken cancellationToken)
  {
    var command = new UpdateProjectCommand(request.ProjectId, request.Name);

    var result = await mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync();
      return;
    }

    if (result.IsSuccess)
    {
      Response = new UpdateProjectResponse(result.Value.Id, result.Value.Name);
    }
  }
}
