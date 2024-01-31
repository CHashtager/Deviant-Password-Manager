using Ardalis.Result;
using Ardalis.SharedKernel;

namespace DeviantPasswordManager.UseCases.Projects.Get;

public record GetProjectQuery(int ProjectId) : IQuery<Result<ProjectWithMembersDto>>;
