using FastEndpoints;
using FluentValidation;

namespace DeviantPasswordManager.Web.Projects;

public class GetProjectByIdValidator : Validator<GetProjectByIdRequest>
{
  public GetProjectByIdValidator()
  {
    RuleFor(x => x.ProjectId)
      .GreaterThan(0);
  }
}
