using Ardalis.Result;
using Ardalis.SharedKernel;

namespace DeviantPasswordManager.UseCases.Projects.AddMember;

public record AddProjectMemberCommand(int ProjectId, string Email) : ICommand<Result>;
