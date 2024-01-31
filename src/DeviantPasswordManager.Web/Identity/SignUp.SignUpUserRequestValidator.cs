using System.ComponentModel.DataAnnotations;
using FastEndpoints;
using FluentValidation;


namespace DeviantPasswordManager.Web.Identity;

public class SignUpUserRequestValidator : Validator<SignUpUserRequest>
{
  public SignUpUserRequestValidator()
  {
    RuleFor(a => a.Email).EmailAddress().NotEmpty().MaximumLength(50);
    RuleFor(a => a.UserName).NotNull().NotEmpty().MaximumLength(50);
    RuleFor(a => a.Password).Length(8, 50);
  }
}
