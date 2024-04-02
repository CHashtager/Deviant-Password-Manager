using Ardalis.Result;
using Ardalis.SharedKernel;

namespace DeviantPasswordManager.UseCases.Projects.Create;

public record CreateProjectCommand(string Name, int? parentId) : ICommand<Result<ProjectDto>>;

