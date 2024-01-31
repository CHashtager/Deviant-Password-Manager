using Ardalis.Result;
using Ardalis.SharedKernel;

namespace DeviantPasswordManager.UseCases.Projects.Delete;

public record DeleteProjectCommand(int ProjectId) : ICommand<Result>;
