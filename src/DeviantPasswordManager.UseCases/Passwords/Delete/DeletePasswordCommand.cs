using Ardalis.Result;
using Ardalis.SharedKernel;

namespace DeviantPasswordManager.UseCases.Passwords.Delete;

public record DeletePasswordCommand(int PasswordId) : ICommand<Result>;
