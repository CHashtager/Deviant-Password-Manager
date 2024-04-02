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
  ) : ICommandHandler<CreatePasswordCommand, Result<PasswordDto>>
{
  public async Task<Result<PasswordDto>> Handle(CreatePasswordCommand request, CancellationToken cancellationToken)
  {
    var projectSpec = new ProjectByIdSpec(request.ProjectId, currentUserService.UserId);
    var project = await projectRepository.FirstOrDefaultAsync(projectSpec, cancellationToken);
    if (project is null) return Result.NotFound("Project not found.");

    var userSpec = new UserByIdentityIdSpec(currentUserService.UserId);
    var user = await userRepository.FirstOrDefaultAsync(userSpec, cancellationToken);
    if (user is null) return Result.NotFound("User not found.");

    var encryptedPassword = passwordService.Encrypt(request.Password, user.PassPhrase);
    var newPassword = new Password(request.Name, request.Username, encryptedPassword, request.Url, project.Id, user.Id);

    var createdPassword = await passwordRepository.AddAsync(newPassword, cancellationToken);

    return Result.Success(new PasswordDto(createdPassword.Id, createdPassword.Name, createdPassword.Username, passwordService.Decrypt(createdPassword.EncryptedPassword, createdPassword.User.PassPhrase), createdPassword.Url));
  }
}
