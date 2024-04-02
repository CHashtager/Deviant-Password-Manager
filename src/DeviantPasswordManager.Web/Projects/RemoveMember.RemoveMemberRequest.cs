using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DeviantPasswordManager.Web.Projects;

public class RemoveProjectMemberRequest
{
  public const string Route = "/Projects/RemoveMember/{ProjectId:int}/";
  public static string BuildRoute(int projectId) => Route.Replace("{ProjectId:int}", projectId.ToString());
  
  public int ProjectId { get; set; }
  
  [FromBody]
  [Required]
  [EmailAddress]
  public string Email { get; set; } = default!;
}
