using FastEndpoints;
using FluentValidation;

namespace DeviantPasswordManager.Web.Passwords;

public class DeletePasswordValidator : Validator<DeletePasswordRequest>
{
  public DeletePasswordValidator()
  {
    RuleFor(a => a.PasswordId).GreaterThan(0);
    RuleFor(a => a.ProjectId).GreaterThan(0);
  }
}
