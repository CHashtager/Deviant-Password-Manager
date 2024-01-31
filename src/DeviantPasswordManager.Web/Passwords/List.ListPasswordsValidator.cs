using FastEndpoints;
using FluentValidation;

namespace DeviantPasswordManager.Web.Passwords;

public class ListPasswordsValidator : Validator<ListPasswordsRequest>
{
  public ListPasswordsValidator()
  {
    RuleFor(x => x.ProjectId)
      .GreaterThan(0);
  }
}
