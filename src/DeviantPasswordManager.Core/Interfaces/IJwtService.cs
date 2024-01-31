using DeviantPasswordManager.Core.IdentityAggregate;

namespace DeviantPasswordManager.Core.Interfaces;

public interface IJwtService
{
  Task<AccessToken> GenerateAsync(ApplicationUser user);
  int? ValidateJwtAccessTokenAsync(string token);
}
