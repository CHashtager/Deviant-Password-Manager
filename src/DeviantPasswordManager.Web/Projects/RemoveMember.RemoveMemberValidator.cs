using DeviantPasswordManager.Infrastructure.Data.Config;
using FastEndpoints;
using FluentValidation;

namespace DeviantPasswordManager.Web.Projects;

public class RemoveProjectMemberValidator : Validator<RemoveProjectMemberRequest>
{
  public RemoveProjectMemberValidator()
  {
    RuleFor(x => x.Email)
      .NotEmpty()
      .NotNull()
      .EmailAddress();

    RuleFor(x => x.ProjectId)
      .GreaterThan(0);
  }
}
