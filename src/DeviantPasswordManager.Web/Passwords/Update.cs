using Ardalis.Result;
using DeviantPasswordManager.UseCases.Passwords.Update;
using FastEndpoints;
using MediatR;

namespace DeviantPasswordManager.Web.Passwords;

public class Update(IMediator mediator) : Endpoint<UpdatePasswordRequest>
{
  public override void Configure()
  {
    Post(UpdatePasswordRequest.Route);
  }

  public override async Task HandleAsync(UpdatePasswordRequest request, CancellationToken cancellationToken)
  {
    var command =
      new UpdatePasswordCommand(request.PasswordId, request.ProjectId,request.Password,request.Name, request.Username, request.Url);

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
  }
}
