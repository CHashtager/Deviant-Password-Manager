using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DeviantPasswordManager.Web.Projects;

public record DeleteProjectRequest
{
  // public const string Route = "/Projects/Delete/{ProjectId:int}";
  // public static string BuildRoute(int projectId) => Route.Replace("{ProjectId:int}", projectId.ToString());

  public const string Route = "/Projects/Delete/";
  
  [FromQuery]
  [Required]
  public int ProjectId { get; set; }
}
