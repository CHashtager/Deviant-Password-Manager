using System.IdentityModel.Tokens.Jwt;

namespace DeviantPasswordManager.Core.IdentityAggregate;

public class AccessToken
{
  public string Token { get; set; }
  public string TokenType { get; set; }
  public int ExpiresIn { get; set; }

  public AccessToken(JwtSecurityToken securityToken)
  {
    Token = new JwtSecurityTokenHandler().WriteToken(securityToken);
    TokenType = "Bearer";
    ExpiresIn = (int)(securityToken.ValidTo - DateTime.UtcNow).TotalSeconds;
  }
}
