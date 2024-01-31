using DeviantPasswordManager.Infrastructure.Data.Config;
using FastEndpoints;
using FluentValidation;

namespace DeviantPasswordManager.Web.Projects;

public class CreateProjectValidator : Validator<CreateProjectRequest>
{
  public CreateProjectValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
  }
}
