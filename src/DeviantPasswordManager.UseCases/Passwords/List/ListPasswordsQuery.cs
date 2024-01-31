using Ardalis.Result;
using Ardalis.SharedKernel;

namespace DeviantPasswordManager.UseCases.Passwords.List;

public record ListPasswordsQuery(int ProjectId) : IQuery<Result<List<PasswordDto>>>;
