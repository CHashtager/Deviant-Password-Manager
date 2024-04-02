using Ardalis.Result;
using Ardalis.SharedKernel;

namespace DeviantPasswordManager.UseCases.Passwords.GetById;

public record GetPasswordByIdQuery(int PasswordId) : IQuery<Result<PasswordDto>>;
