using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DeviantPasswordManager.Web.Passwords;

public class ListPasswordsRequest
{
  public const string Route = "/Passwords/{ProjectId:int}/";
  public static string BuildRoute(int projectId) => Route.Replace("{ProjectId:int}", projectId.ToString());

  public int ProjectId { get; set; }
  
}
