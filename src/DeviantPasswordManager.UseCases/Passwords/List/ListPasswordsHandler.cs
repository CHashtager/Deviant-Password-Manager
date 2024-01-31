using Ardalis.Result;
using Ardalis.SharedKernel;
using DeviantPasswordManager.Core.IdentityAggregate;
using DeviantPasswordManager.Core.IdentityAggregate.Specifications;
using DeviantPasswordManager.Core.Interfaces;
using DeviantPasswordManager.Core.PasswordAggregate;
using DeviantPasswordManager.Core.PasswordAggregate.Specifications;

namespace DeviantPasswordManager.UseCases.Passwords.List;

public class ListPasswordsHandler(
  IReadRepository<Password> passwordRepository,
  IPasswordService passwordService,
  ICurrentUserService currentUserService) : IQueryHandler<ListPasswordsQuery, Result<List<PasswordDto>>>
{
  public async Task<Result<List<PasswordDto>>> Handle(ListPasswordsQuery request, CancellationToken cancellationToken)
  {
    var passwordSpec = new PasswordsByProjectIdSpec(request.ProjectId, currentUserService.UserId);
    var passwords = await passwordRepository.ListAsync(passwordSpec, cancellationToken);

    return Result.Success(passwords.Select(password => new PasswordDto(password.Id, password.Name, password.Username,
      passwordService.Decrypt(password.EncryptedPassword, password.User.PassPhrase), password.Url)).ToList());
  }
}
