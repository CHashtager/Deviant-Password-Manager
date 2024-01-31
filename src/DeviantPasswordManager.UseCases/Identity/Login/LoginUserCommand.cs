using Ardalis.Result;
using Ardalis.SharedKernel;

namespace DeviantPasswordManager.UseCases.Identity.Login;

public record LoginUserCommand(string Email, string Password) : ICommand<Result<LoginDto>>;
