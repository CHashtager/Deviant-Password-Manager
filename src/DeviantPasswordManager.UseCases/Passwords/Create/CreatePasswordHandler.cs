using Ardalis.Result;
using Ardalis.SharedKernel;
using DeviantPasswordManager.Core.IdentityAggregate;
using DeviantPasswordManager.Core.IdentityAggregate.Specifications;
using DeviantPasswordManager.Core.Interfaces;
using DeviantPasswordManager.Core.PasswordAggregate;
using DeviantPasswordManager.Core.ProjectAggregate;
using DeviantPasswordManager.Core.ProjectAggregate.Specifications;

namespace DeviantPasswordManager.UseCases.Passwords.Create;

public class CreatePasswordHandler(
  IRepository<Password> passwordRepository,
  IReadRepository<Project> projectRepository,
  IReadRepository<User> userRepository,
  ICurrentUserService currentUserService,
  IPasswordService passwordService
  ) : ICommandHandler<CreatePasswordCommand, Result>
{
  public async Task<Result> Handle(CreatePasswordCommand request, CancellationToken cancellationToken)
  {
    var projectSpec = new ProjectByIdSpec(request.ProjectId, currentUserService.UserId);
    var project = await projectRepository.FirstOrDefaultAsync(projectSpec, cancellationToken);
    if (project is null) return Result.NotFound("Project not found.");

    var userSpec = new UserByIdentityIdSpec(currentUserService.UserId);
    var user = await userRepository.FirstOrDefaultAsync(userSpec, cancellationToken);
    if (user is null) return Result.NotFound("User not found.");

    var encryptedPassword = passwordService.Encrypt(request.Password, user.PassPhrase);
    var newPassword = new Password(request.Name, request.Username, encryptedPassword, request.Url, project.Id, user.Id);

    await passwordRepository.AddAsync(newPassword, cancellationToken);

    return Result.Success();
  }
}
