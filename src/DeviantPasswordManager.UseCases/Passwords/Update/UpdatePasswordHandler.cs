using Ardalis.Result;
using Ardalis.SharedKernel;
using DeviantPasswordManager.Core.Interfaces;
using DeviantPasswordManager.Core.PasswordAggregate;
using DeviantPasswordManager.Core.PasswordAggregate.Specifications;

namespace DeviantPasswordManager.UseCases.Passwords.Update;

public class UpdatePasswordHandler(IRepository<Password> passwordRepository, IPasswordService passwordService,
  ICurrentUserService currentUserService) : ICommandHandler<UpdatePasswordCommand, Result<PasswordDto>>
{
  public async Task<Result<PasswordDto>> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
  {
    var passwordSpec = new PasswordOwnerSpec(request.PasswordId, currentUserService.UserId);
    var password = await passwordRepository.FirstOrDefaultAsync(passwordSpec, cancellationToken);
    if (password is null) return Result.NotFound("Password not found");

    password.UpdateProperties(request.Name, request.Username, request.Url);
    password.EncryptedPassword = passwordService.Encrypt(request.NewPassword, password.User.PassPhrase);

    await passwordRepository.UpdateAsync(password, cancellationToken);

    return Result.Success(new PasswordDto(password.Id, password.Name, password.Username, passwordService.Decrypt(password.EncryptedPassword, password.User.PassPhrase), password.Url));
  }
}
