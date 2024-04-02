using Ardalis.Result;
using DeviantPasswordManager.UseCases.Passwords.Update;
using FastEndpoints;
using MediatR;

namespace DeviantPasswordManager.Web.Passwords;

public class Update(IMediator mediator) : Endpoint<UpdatePasswordRequest, UpdatePasswordResponse>
{
  public override void Configure()
  {
    Put(UpdatePasswordRequest.Route);
  }

  public override async Task HandleAsync(UpdatePasswordRequest request, CancellationToken cancellationToken)
  {
    var command =
      new UpdatePasswordCommand(request.PasswordId,request.Password,request.Name, request.Username, request.Url);

    var result = await mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync();
      return;
    }

    if (result.IsSuccess)
    {
      Response = new UpdatePasswordResponse(result.Value.Id, result.Value.Name, result.Value.Username,
        result.Value.Password, result.Value.Url);
    }
  }
}
