using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace DeviantPasswordManager.Web.Passwords;

public class DeletePasswordRequest
{
  public const string Route = "/Passwords/{PasswordId:int}/";
  public static string BuildRoute(int passwordId) => Route.Replace("{PasswordId:int}", passwordId.ToString());

  public int PasswordId { get; set; }
  
}
