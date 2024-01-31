using Ardalis.Result;
using Ardalis.SharedKernel;
using DeviantPasswordManager.Core.IdentityAggregate;
using DeviantPasswordManager.Core.IdentityAggregate.Specifications;
using DeviantPasswordManager.Core.Interfaces;
using DeviantPasswordManager.Core.ProjectAggregate;
using DeviantPasswordManager.Core.ProjectAggregate.Specifications;

namespace DeviantPasswordManager.UseCases.Projects.RemoveMember;

public class RemoveProjectMemberHandler(
  IRepository<Project> projectRepository,
  IReadRepository<User> userRepository,
  ICurrentUserService currentUserService) : ICommandHandler<RemoveProjectMemberCommand, Result>
{
  public async Task<Result> Handle(RemoveProjectMemberCommand request, CancellationToken cancellationToken)
  {
    var projectSpec = new ProjectByIdSpec(request.ProjectId, currentUserService.UserId);
    var project = await projectRepository.FirstOrDefaultAsync(projectSpec, cancellationToken);
    if (project is null) return Result.NotFound("Project not found");

    var userSpec = new UserByEmailSpec(request.Email);
    var member = await userRepository.FirstOrDefaultAsync(userSpec, cancellationToken);
    if (member is null) return Result.NotFound("User not found.");

    if (member.UserId == currentUserService.UserId) return Result.Conflict("You can not remove yourself from members.");
    
    if (project.Members.Any(m => m != member)) return Result.NotFound("Member not found");

    project.RemoveUser(member);

    await projectRepository.UpdateAsync(project, cancellationToken);
    return Result.Success();
  }
}
