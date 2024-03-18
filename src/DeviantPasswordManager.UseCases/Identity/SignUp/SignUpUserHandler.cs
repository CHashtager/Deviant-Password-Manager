using Ardalis.Result;
using Ardalis.SharedKernel;
using DeviantPasswordManager.Core.Exceptions;
using DeviantPasswordManager.Core.IdentityAggregate;
using DeviantPasswordManager.Core.ProjectAggregate;
using Microsoft.AspNetCore.Identity;


namespace DeviantPasswordManager.UseCases.Identity.SignUp;

public class SignUpUserHandler
  (UserManager<ApplicationUser> userManager, IRepository<User> userRepository, IRepository<Project> projectRepository) : ICommandHandler<SignUpUserCommand,
    Result>
{
  public async Task<Result> Handle(SignUpUserCommand request, CancellationToken cancellationToken)
  {
    var newUser = new ApplicationUser() { UserName = request.UserName, Email = request.Email };
    var createdUserResult = await userManager.CreateAsync(newUser, request.Password);

    if (!createdUserResult.Succeeded) throw new IdentityException(createdUserResult.Errors);

    var newDbUser = new User(newUser.Id, request.Email.ToUpper(), request.PassPhrase);
    await userRepository.AddAsync(newDbUser, cancellationToken);

    await projectRepository.AddAsync(new Project("Default", newDbUser.Id, null));
    
    return Result.Success();
  }
}
