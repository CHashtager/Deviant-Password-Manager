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
    Description(b => 
        b.Accepts<DeletePasswordRequest>().
          Produces(204).
          Produces(401).
          Produces(403).
          Produces(404),
      clearDefaults: true);
  }

  public override async Task HandleAsync(
    DeletePasswordRequest request,
    CancellationToken cancellationToken)
  {
    var command = new DeletePasswordCommand(request.PasswordId);

    var result = await mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      await SendNoContentAsync(cancellationToken);
    }

    ;
  }
}
