using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DeviantPasswordManager.Web.Projects;

public class UpdateProjectRequest
{
  public const string Route = "/Projects/{ProjectId:int}/";
  public static string BuildRoute(int projectId) => Route.Replace("{ProjectId:int}", projectId.ToString());


  public int ProjectId { get; set; } = default!;
  
  [FromBody]
  [Required]
  public string Name { get; set; } = default!;
}
