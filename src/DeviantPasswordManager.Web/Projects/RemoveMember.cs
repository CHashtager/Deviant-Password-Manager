using Ardalis.Result;
using DeviantPasswordManager.UseCases.Projects.RemoveMember;
using FastEndpoints;
using MediatR;

namespace DeviantPasswordManager.Web.Projects;

public class RemoveMember(IMediator mediator) : Endpoint<RemoveProjectMemberRequest>
{
  public override void Configure()
  {
    Delete(RemoveProjectMemberRequest.Route);
    Description(b => 
      b.Accepts<RemoveProjectMemberRequest>().
        Produces(204).
        Produces(401).
        Produces(403).
        Produces(404),
      clearDefaults: true);
  }

  public override async Task HandleAsync(
    RemoveProjectMemberRequest request,
    CancellationToken cancellationToken)
  {
    var command = new RemoveProjectMemberCommand(request.ProjectId, request.Email);

    var result = await mediator.Send(command);
    
    switch (result.Status)
    {
      case ResultStatus.NotFound:
        await SendNotFoundAsync(cancellationToken);
        // await SendAsync(result.Errors.FirstOrDefault()!, 404, cancellationToken);
        return;
      case ResultStatus.Conflict:
        await SendForbiddenAsync(cancellationToken);
        // await SendAsync(result.Errors.FirstOrDefault()!, 409, cancellationToken);
        return;
    }


    if (result.IsSuccess)
    {
      await SendNoContentAsync(cancellationToken);
    }
  }
}
