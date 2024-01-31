using Ardalis.Result;
using Ardalis.SharedKernel;
using DeviantPasswordManager.Core.Exceptions;
using DeviantPasswordManager.Core.IdentityAggregate;
using DeviantPasswordManager.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DeviantPasswordManager.UseCases.Identity.Login;

public class LoginUserHandler
  (UserManager<ApplicationUser> userManager, IJwtService jwtService) : ICommandHandler<LoginUserCommand,
    Result<LoginDto>>
{
  public async Task<Result<LoginDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
  {
    var user = await userManager.FindByEmailAsync(request.Email);
    if (user == null)
      throw new AuthenticationException(new[] { "Email or Password incorrect." });

    var isPasswordValid = await userManager.CheckPasswordAsync(user, request.Password);
    if (!isPasswordValid)
      throw new AuthenticationException(new[] { "Email or Password incorrect." });

    var jwt = await jwtService.GenerateAsync(user);
    user.LastLoginDate = DateTime.UtcNow;
    await userManager.UpdateAsync(user);

    return Result.Success(new LoginDto(Token: jwt.Token, TokenType: jwt.TokenType, ExpiresIn: jwt.ExpiresIn));
  }
}
