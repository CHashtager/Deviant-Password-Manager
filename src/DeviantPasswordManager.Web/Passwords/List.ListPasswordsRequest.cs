using System.ComponentModel.DataAnnotations;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace DeviantPasswordManager.Web.Passwords;

public class ListPasswordsRequest
{
  public const string Route = "/Passwords/";
  // public static string BuildRoute(int projectId) => Route.Replace("{ProjectId:int}", projectId.ToString());

  [QueryParam]
  [Required]
  public int ProjectId { get; set; }
  
}
