using DeviantPasswordManager.UseCases.Projects.Create;
using DeviantPasswordManager.UseCases.Projects.List;
using FastEndpoints;
using MediatR;

namespace DeviantPasswordManager.Web.Projects;

public class List(IMediator mediator) : EndpointWithoutRequest<ListProjectsResponse>
{
  public override void Configure()
  {
    Get(ListProjectsRequest.Route);
    // AllowAnonymous();
  }

  public override async Task HandleAsync(
    CancellationToken cancellationToken)
  {
    var result = await mediator.Send(new ListProjectsQuery());

    if (result.IsSuccess)
    {
      Response = new ListProjectsResponse
      {
        Projects = result.Value.Select(p => new ProjectRecord(p.Id, p.Name)).ToList()
      };
    }
  }
}
