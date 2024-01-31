using System.ComponentModel.DataAnnotations;


namespace DeviantPasswordManager.Web.Identity;

public class LoginUserResponse
{
  public string Token { get; set; } = default!;
  public string TokenType { get; set; } = default!;
  public int ExpiresIn { get; set; }
}
