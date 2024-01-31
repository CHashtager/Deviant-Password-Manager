using Ardalis.Result;
using Ardalis.SharedKernel;

namespace DeviantPasswordManager.UseCases.Passwords.Delete;

public record DeletePasswordCommand(int PasswordId, int ProjectId) : ICommand<Result>;
