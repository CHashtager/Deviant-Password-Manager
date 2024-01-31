using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace DeviantPasswordManager.Web.Passwords;

public class DeletePasswordRequest
{
  public const string Route = "/Passwords/Delete/";

  [FromQuery]
  [Required] 
  public int PasswordId { get; set; } = default!;
  
  [FromQuery]
  [Required]
  public int ProjectId { get; set; } = default!;
}
