using Ardalis.Result;
using Ardalis.SharedKernel;
using DeviantPasswordManager.Core.IdentityAggregate;
using DeviantPasswordManager.Core.IdentityAggregate.Specifications;
using DeviantPasswordManager.Core.Interfaces;
using DeviantPasswordManager.Core.PasswordAggregate;
using DeviantPasswordManager.Core.PasswordAggregate.Specifications;

namespace DeviantPasswordManager.UseCases.Passwords.GetById;

public class GetPasswordByIdHandler(
  IReadRepository<Password> passwordRepository,
  ICurrentUserService currentUserService,
  IPasswordService passwordService
) : IQueryHandler<GetPasswordByIdQuery, Result<PasswordDto>>
{
  public async Task<Result<PasswordDto>> Handle(GetPasswordByIdQuery request, CancellationToken cancellationToken)
  {
    var passwordSpec = new PasswordByIdProjectSpec(request.PasswordId, request.ProjectId, currentUserService.UserId);
    var password = await passwordRepository.FirstOrDefaultAsync(passwordSpec, cancellationToken);
    if (password is null) return Result.NotFound("Password not found");

    return Result.Success(new PasswordDto(password.Id, password.Name, password.Username,
      passwordService.Decrypt(password.EncryptedPassword, password.User.PassPhrase), password.Url));
  }
}
