using FastEndpoints;
using FluentValidation;

namespace DeviantPasswordManager.Web.Passwords;

public class CreatePasswordValidator : Validator<CreatePasswordRequest>
{
  public CreatePasswordValidator()
  {
    RuleFor(a => a.Name).NotNull().NotEmpty().MaximumLength(100);
    RuleFor(a => a.Username).NotNull().NotEmpty().MaximumLength(100);
    RuleFor(a => a.Password).NotNull().NotEmpty().MaximumLength(100);
    RuleFor(a => a.Url).MaximumLength(100);
    RuleFor(a => a.ProjectId).GreaterThan(0);
  }
}
