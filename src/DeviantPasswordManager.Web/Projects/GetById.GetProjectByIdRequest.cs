using System.ComponentModel.DataAnnotations;
using FastEndpoints;

namespace DeviantPasswordManager.Web.Projects;

public class GetProjectByIdRequest
{
  public const string Route = "/Projects/{ProjectId:int}/";
  public static string BuildRoute(int projectId) => Route.Replace("{ProjectId:int}", projectId.ToString());

  // public const string Route = "/Projects/GetById/";

  // [QueryParam]
  // [Required]
  public int ProjectId { get; set; }
}
