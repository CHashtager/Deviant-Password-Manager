using DeviantPasswordManager.UseCases.Projects.Create;
using FastEndpoints;
using MediatR;

namespace DeviantPasswordManager.Web.Projects;

public class Create(IMediator mediator) : Endpoint<CreateProjectRequest>
{
  public override void Configure()
  {
    Post(CreateProjectRequest.Route);
    // AllowAnonymous();
  }

  public override async Task HandleAsync(
    CreateProjectRequest request,
    CancellationToken cancellationToken)
  {
    var command = new CreateProjectCommand(request.Name);

    var result = await mediator.Send(command);

    if (result.IsSuccess)
    {
      await SendNoContentAsync(cancellationToken);
    }
  }
}
