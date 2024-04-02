using Ardalis.Result;
using Ardalis.SharedKernel;

namespace DeviantPasswordManager.UseCases.Projects.Update;

public record UpdateProjectCommand(int Id, string Name) : ICommand<Result<ProjectDto>>;

