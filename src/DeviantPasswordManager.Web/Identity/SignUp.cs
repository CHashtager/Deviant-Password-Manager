using DeviantPasswordManager.UseCases.Identity.SignUp;
using FastEndpoints;
using MediatR;

namespace DeviantPasswordManager.Web.Identity;

public class SignUp(IMediator mediator) : Endpoint<SignUpUserRequest>
{
  public override void Configure()
  {
    Post(SignUpUserRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    SignUpUserRequest request,
    CancellationToken cancellationToken)
  {
    var command = new SignUpUserCommand(request.UserName, request.Email, request.Password, request.PassPhrase);

    var result = await mediator.Send(command);

    if (result.IsSuccess)
    {
      await SendCreatedAtAsync<Login>(null, null);
    }
  }
}
