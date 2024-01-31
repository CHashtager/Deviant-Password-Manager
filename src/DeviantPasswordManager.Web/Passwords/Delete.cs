using Ardalis.Result;
using DeviantPasswordManager.UseCases.Passwords.Delete;
using FastEndpoints;
using MediatR;

namespace DeviantPasswordManager.Web.Passwords;

public class Delete(IMediator mediator) : Endpoint<DeletePasswordRequest>
{
  public override void Configure()
  {
    Delete(DeletePasswordRequest.Route);
  }

  public override async Task HandleAsync(
    DeletePasswordRequest request,
    CancellationToken cancellationToken)
  {
    var command = new DeletePasswordCommand(request.PasswordId, request.ProjectId);

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

    ;
  }
}
