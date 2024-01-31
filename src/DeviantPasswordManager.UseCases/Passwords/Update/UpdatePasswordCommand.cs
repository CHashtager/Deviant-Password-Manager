using Ardalis.Result;
using Ardalis.SharedKernel;

namespace DeviantPasswordManager.UseCases.Passwords.Update;

public record UpdatePasswordCommand(int PasswordId, int ProjectId, string NewPassword, string Name, string Username, string Url) : ICommand<Result>;
