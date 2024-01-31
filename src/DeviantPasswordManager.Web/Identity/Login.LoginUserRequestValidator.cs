using System.ComponentModel.DataAnnotations;
using FastEndpoints;
using FluentValidation;


namespace DeviantPasswordManager.Web.Identity;

public class LoginUserRequestValidator : Validator<LoginUserRequest>
{
  public LoginUserRequestValidator()
  {
    RuleFor(a => a.Email).EmailAddress().NotEmpty().MaximumLength(50);
    RuleFor(a => a.Password).Length(8, 50);
  }
}
