using Ardalis.Result;
using Ardalis.SharedKernel;
using DeviantPasswordManager.Core.Exceptions;
using DeviantPasswordManager.Core.IdentityAggregate;
using DeviantPasswordManager.Core.IdentityAggregate.Specifications;
using DeviantPasswordManager.Core.Interfaces;
using DeviantPasswordManager.Core.ProjectAggregate;

namespace DeviantPasswordManager.UseCases.Projects.Create;

public class CreateProjectHandler(IRepository<Project> repository, ICurrentUserService currentUserService, IReadRepository<User> userRepository): ICommandHandler<CreateProjectCommand, Result> 
{
  public async Task<Result> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
  {

    var user = await userRepository.FirstOrDefaultAsync(new UserByIdentityIdSpec(currentUserService.UserId),
      cancellationToken);
    var newProject = new Project(request.Name, user!.Id, request.parentId);
    var createdItem = await repository.AddAsync(newProject, cancellationToken);
    return Result.Success();
  }
}
