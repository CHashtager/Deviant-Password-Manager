using Ardalis.Result;
using Ardalis.SharedKernel;

namespace DeviantPasswordManager.UseCases.Passwords.Create;

public record CreatePasswordCommand(string Name, string Username, string Password, string Url, int ProjectId) : ICommand<Result>;
