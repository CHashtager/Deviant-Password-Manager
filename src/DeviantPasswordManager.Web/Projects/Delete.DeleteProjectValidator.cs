using FastEndpoints;
using FluentValidation;

namespace DeviantPasswordManager.Web.Projects;

public class DeleteProjectValidator : Validator<DeleteProjectRequest>
{
  public DeleteProjectValidator()
  {
    RuleFor(x => x.ProjectId)
      .GreaterThan(0);
  }
}
