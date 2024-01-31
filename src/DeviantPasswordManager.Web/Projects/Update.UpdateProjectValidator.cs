using DeviantPasswordManager.Infrastructure.Data.Config;
using FastEndpoints;
using FluentValidation;

namespace DeviantPasswordManager.Web.Projects;

public class UpdateProjectValidator : Validator<UpdateProjectRequest>
{
  public UpdateProjectValidator()
  {
    RuleFor(x => x.ProjectId)
      .GreaterThan(0);
    
    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
  }
}
