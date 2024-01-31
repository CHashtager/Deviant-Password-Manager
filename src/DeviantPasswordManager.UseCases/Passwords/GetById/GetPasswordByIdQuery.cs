using Ardalis.Result;
using Ardalis.SharedKernel;

namespace DeviantPasswordManager.UseCases.Passwords.GetById;

public record GetPasswordByIdQuery(int PasswordId, int ProjectId) : IQuery<Result<PasswordDto>>;
