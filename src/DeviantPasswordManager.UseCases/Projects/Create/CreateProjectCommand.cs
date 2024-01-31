using Ardalis.Result;
using Ardalis.SharedKernel;

namespace DeviantPasswordManager.UseCases.Projects.Create;

public record CreateProjectCommand(string Name) : ICommand<Result>;

