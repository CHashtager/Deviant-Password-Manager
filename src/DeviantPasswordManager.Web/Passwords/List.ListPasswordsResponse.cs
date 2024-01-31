using System.ComponentModel.DataAnnotations;

namespace DeviantPasswordManager.Web.Passwords;

public class ListPasswordsResponse
{
  public List<PasswordRecord> Passwords { get; set; } = new();
}
