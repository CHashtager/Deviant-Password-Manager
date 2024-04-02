using Ardalis.Result;
using DeviantPasswordManager.UseCases.Projects.AddMember;
using FastEndpoints;
using MediatR;

namespace DeviantPasswordManager.Web.Projects;

public class AddMember(IMediator mediator) : Endpoint<AddProjectMemberRequest, AddProjectMemberResponse>
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
        await SendNotFoundAsync(cancellationToken);
        return;
      case ResultStatus.Conflict:
        await SendForbiddenAsync(cancellationToken);
        return;
    }

    if (result.IsSuccess)
    {
      Response = new AddProjectMemberResponse(result.Value.Id, result.Value.Name,
        result.Value.Members.Select(member => new ProjectMemberRecord(member.Email)).ToList());
    }
  }
}
