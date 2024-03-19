using DeviantPasswordManager.UseCases.Projects.List;
using FastEndpoints;
using MediatR;

namespace DeviantPasswordManager.Web.Projects;

public class List(IMediator mediator) : Endpoint<ListProjectsRequest, ListProjectsResponse>
{
  public override void Configure()
  {
    Get(ListProjectsRequest.Route);
    // AllowAnonymous();
  }

  public override async Task HandleAsync(ListProjectsRequest req, CancellationToken ct)
  {
    var result = await mediator.Send(new ListProjectsQuery(req.ParentId));

    if (result.IsSuccess)
    {
      Response = new ListProjectsResponse
      {
        Projects = result.Value.Select(p => new ProjectRecord(p.Id, p.Name, p.HasChildren)).ToList()
      };
    }  }
}
