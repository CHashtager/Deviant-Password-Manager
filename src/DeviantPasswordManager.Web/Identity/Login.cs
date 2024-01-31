using DeviantPasswordManager.UseCases.Identity.Login;
using FastEndpoints;
using MediatR;

namespace DeviantPasswordManager.Web.Identity;

public class Login(IMediator mediator) : Endpoint<LoginUserRequest>
{
  public override void Configure()
  {
    Post(LoginUserRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    LoginUserRequest request,
    CancellationToken cancellationToken)
  {
    var command = new LoginUserCommand(request.Email, request.Password);

    var result = await mediator.Send(command);

    if (result.IsSuccess)
    {
      var dto = result.Value;
      Response = new LoginUserResponse() { Token = dto.Token, TokenType = dto.TokenType, ExpiresIn = dto.ExpiresIn };
    }
    
  }
}
