using Ardalis.Result;
using Ardalis.SharedKernel;
using DeviantPasswordManager.Core.IdentityAggregate;
using DeviantPasswordManager.Core.IdentityAggregate.Specifications;
using DeviantPasswordManager.Core.Interfaces;
using DeviantPasswordManager.Core.ProjectAggregate;
using DeviantPasswordManager.Core.ProjectAggregate.Specifications;

namespace DeviantPasswordManager.UseCases.Projects.AddMember;

public class AddProjectMemberHandler(IRepository<Project> projectRepository, IReadRepository<User> userRepository, ICurrentUserService currentUserService) : ICommandHandler<AddProjectMemberCommand, Result>
{
  public async Task<Result> Handle(AddProjectMemberCommand request, CancellationToken cancellationToken)
  {
    var projectSpec = new ProjectByIdSpec(request.ProjectId, currentUserService.UserId);
    var project = await projectRepository.FirstOrDefaultAsync(projectSpec, cancellationToken);
    if (project is null) return Result.NotFound("Project not found");

    var userSpec = new UserByEmailSpec(request.Email);
    var member = await userRepository.FirstOrDefaultAsync(userSpec, cancellationToken);
    if (member is null) return Result.NotFound("User not found.");

    if (member.UserId == currentUserService.UserId) return Result.Conflict("You cannot add yourself to members");
    
    project.AddUser(member);

    await projectRepository.UpdateAsync(project, cancellationToken);
    return Result.Success();
  }
}
