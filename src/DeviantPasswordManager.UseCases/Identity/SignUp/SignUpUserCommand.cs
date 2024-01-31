using Ardalis.Result;
using Ardalis.SharedKernel;

namespace DeviantPasswordManager.UseCases.Identity.SignUp;

public record SignUpUserCommand
  (string UserName, string Email, string Password, string PassPhrase) : ICommand<Result>;
