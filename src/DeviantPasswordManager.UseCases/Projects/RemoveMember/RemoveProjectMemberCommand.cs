using Ardalis.Result;
using Ardalis.SharedKernel;

namespace DeviantPasswordManager.UseCases.Projects.RemoveMember;

public record RemoveProjectMemberCommand(int ProjectId, string Email) : ICommand<Result>;
