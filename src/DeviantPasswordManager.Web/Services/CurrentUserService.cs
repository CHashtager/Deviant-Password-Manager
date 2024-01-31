using System.Security.Claims;
using DeviantPasswordManager.Core.Interfaces;

namespace DeviantPasswordManager.Web.Services;

public class CurrentUserService : ICurrentUserService
{
  public CurrentUserService(IHttpContextAccessor httpContextAccessor)
  {
    UserId = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)!;
  }

  public string UserId { get; }
}
