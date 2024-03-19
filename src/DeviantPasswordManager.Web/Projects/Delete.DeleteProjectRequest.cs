using System.ComponentModel.DataAnnotations;
using FastEndpoints;

namespace DeviantPasswordManager.Web.Projects;

public record DeleteProjectRequest
{
  // public const string Route = "/Projects/Delete/{ProjectId:int}";
  // public static string BuildRoute(int projectId) => Route.Replace("{ProjectId:int}", projectId.ToString());

  public const string Route = "/Projects/Delete/";
  
  [QueryParam]
  [Required]
  public int ProjectId { get; set; }
}
