using Ardalis.Result;
using DeviantPasswordManager.UseCases.Projects.AddMember;
using FastEndpoints;
using MediatR;

namespace DeviantPasswordManager.Web.Projects;

public class AddMember(IMediator mediator) : Endpoint<AddProjectMemberRequest>
{
  public override void Configure()
  {
    Post(AddProjectMemberRequest.Route);
  }

  public override async Task HandleAsync(
    AddProjectMemberRequest request,
    CancellationToken cancellationToken)
  {
    var command = new AddProjectMemberCommand(request.ProjectId, request.Email);

    var result = await mediator.Send(command);

    switch (result.Status)
    {
      case ResultStatus.NotFound:
        // await SendNotFoundAsync(cancellationToken);
        await SendAsync(result.Errors.FirstOrDefault()!, 404, cancellationToken);
        return;
      case ResultStatus.Conflict:
        // await SendForbiddenAsync(cancellationToken);
        await SendAsync(result.Errors.FirstOrDefault()!, 409, cancellationToken);
        return;
    }

    if (result.IsSuccess)
    {
      await SendNoContentAsync(cancellationToken);
    }
  }
}
