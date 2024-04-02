using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DeviantPasswordManager.Web.Passwords;

public class GetPasswordByIdRequest
{
  public const string Route = "/Passwords/{PasswordId:int}/";
  public static string BuildRoute(int passwordId) => Route.Replace("{PasswordId:int}", passwordId.ToString());

  public int PasswordId { get; set; }

}
