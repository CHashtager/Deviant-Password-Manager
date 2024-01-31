using Ardalis.Result;
using Ardalis.SharedKernel;

namespace DeviantPasswordManager.UseCases.Projects.List;

public record ListProjectsQuery : IQuery<Result<List<ProjectDto>>>;
