using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DeviantPasswordManager.Web.Projects;

public class RemoveProjectMemberRequest
{
  public const string Route = "/Projects/RemoveMember/";

  [FromBody]
  [Required]
  public int ProjectId { get; set; }
  
  [FromBody]
  [Required]
  [EmailAddress]
  public string Email { get; set; } = default!;
}
