using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DeviantPasswordManager.Web.Projects;

public class GetProjectByIdRequest
{
  // public const string Route = "/Projects/GetById/{ProjectId:int}";
  // public static string BuildRoute(int projectId) => Route.Replace("{ProjectId:int}", projectId.ToString());

  public const string Route = "/Projects/GetById/";

  [FromQuery]
  [Required]
  public int ProjectId { get; set; }
}
