using DeviantPasswordManager.UseCases.Projects.Create;
using FastEndpoints;
using MediatR;

namespace DeviantPasswordManager.Web.Projects;

public class Create(IMediator mediator) : Endpoint<CreateProjectRequest, CreateProjectResponse>
{
  public override void Configure()
  {
    Post(CreateProjectRequest.Route);
  }

  public override async Task HandleAsync(
    CreateProjectRequest request,
    CancellationToken cancellationToken)
  {
    var command = new CreateProjectCommand(request.Name, request.ParentId);

    var result = await mediator.Send(command);

    if (result.IsSuccess)
    {
      await SendCreatedAtAsync<GetById>(new {ProjectId = result.Value.Id}, new CreateProjectResponse(result.Value.Id, result.Value.Name));
    }
  }
}
