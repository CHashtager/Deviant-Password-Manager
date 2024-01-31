using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;


namespace DeviantPasswordManager.Web.Identity;

public class LoginUserRequest
{
  public const string Route = "/Identity/Login/";

  [FromBody]
  [Required]
  [EmailAddress]
  public string Email { get; set; } = default!;

  [FromBody]
  [Required]
  public string Password { get; set; } = default!;
}
