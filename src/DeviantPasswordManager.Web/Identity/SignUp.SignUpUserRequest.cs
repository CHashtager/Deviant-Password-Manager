using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;


namespace DeviantPasswordManager.Web.Identity;

public class SignUpUserRequest
{
  public const string Route = "/Identity/SignUp/";

  [FromBody]
  [Required]
  public string UserName { get; set; } = default!;

  [FromBody]
  [Required]
  [EmailAddress]
  public string Email { get; set; } = default!;

  [FromBody]
  [Required]
  public string Password { get; set; } = default!;

  [FromBody]
  [Required]
  public string PassPhrase { get; set; } = default!;
}
