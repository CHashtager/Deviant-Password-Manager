using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace DeviantPasswordManager.Web.Passwords;

public class CreatePasswordRequest
{
  public const string Route = "/Passwords/";

  [FromBody] [Required] public string Name { get; set; } = default!;
  [FromBody] [Required] public string Username { get; set; } = default!;
  [FromBody] [Required] public string Password { get; set; } = default!;
  [FromBody] public string Url { get; set; } = default!;
  [FromBody] [Required] public int ProjectId { get; set; } = default!;
}
