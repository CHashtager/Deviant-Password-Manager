using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace DeviantPasswordManager.Web.Passwords;

public class DeletePasswordRequest
{
  public const string Route = "/Passwords/Delete/";

  [QueryParam]
  [Required] 
  public int PasswordId { get; set; } = default!;
  
  [QueryParam]
  [Required]
  public int ProjectId { get; set; } = default!;
}
