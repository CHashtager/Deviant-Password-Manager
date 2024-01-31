using FastEndpoints;
using MediatR;
using Ardalis.Result;
using DeviantPasswordManager.UseCases.Projects.Get;

namespace DeviantPasswordManager.Web.Projects;

public class GetById(IMediator mediator)
  : Endpoint<GetProjectByIdRequest, GetProjectByIdResponse>
{
  public override void Configure()
  {
    Get(GetProjectByIdRequest.Route);
  }

  public override async Task HandleAsync(GetProjectByIdRequest request,
    CancellationToken cancellationToken)
  {
    var command = new GetProjectQuery(request.ProjectId);

    var result = await mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new GetProjectByIdResponse(result.Value.Id, result.Value.Name,
        result.Value.Members.Select(member => new ProjectMemberRecord(member.Email)).ToList());
    }
  }
}
