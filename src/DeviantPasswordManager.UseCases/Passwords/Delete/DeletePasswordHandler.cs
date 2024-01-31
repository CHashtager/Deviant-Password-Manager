using Ardalis.Result;
using Ardalis.SharedKernel;
using DeviantPasswordManager.Core.IdentityAggregate;
using DeviantPasswordManager.Core.IdentityAggregate.Specifications;
using DeviantPasswordManager.Core.Interfaces;
using DeviantPasswordManager.Core.PasswordAggregate;
using DeviantPasswordManager.Core.PasswordAggregate.Specifications;
using DeviantPasswordManager.Core.ProjectAggregate;
using DeviantPasswordManager.Core.ProjectAggregate.Specifications;

namespace DeviantPasswordManager.UseCases.Passwords.Delete;

public class DeletePasswordHandler(
  IRepository<Password> passwordRepository,
  ICurrentUserService currentUserService,
  IPasswordService passwordService
  ) : ICommandHandler<DeletePasswordCommand, Result>
{
  public async Task<Result> Handle(DeletePasswordCommand request, CancellationToken cancellationToken)
  {
    var passwordSpec = new PasswordAuthedSpec(request.PasswordId, request.ProjectId, currentUserService.UserId);
    var password = await passwordRepository.FirstOrDefaultAsync(passwordSpec, cancellationToken);
    if (password is null) return Result.NotFound("Password not found.");
    
    return await passwordService.DeletePassword(password.Id);
  }
}
