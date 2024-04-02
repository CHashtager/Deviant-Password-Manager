using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace DeviantPasswordManager.Web.Passwords;

public class UpdatePasswordRequest
{
  public const string Route = "/Passwords/{PasswordId:int}/";
  public static string BuildRoute(int passwordId) => Route.Replace("{PasswordId:int}", passwordId.ToString());

  public int PasswordId { get; set; }
  [FromBody] [Required] public string Name { get; set; } = default!;
  [FromBody] [Required] public string Username { get; set; } = default!;
  [FromBody] [Required] public string Password { get; set; } = default!;
  [FromBody] public string Url { get; set; } = default!;
}
