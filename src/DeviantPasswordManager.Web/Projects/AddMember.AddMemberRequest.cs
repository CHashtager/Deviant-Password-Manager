using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DeviantPasswordManager.Web.Projects;

public class AddProjectMemberRequest
{
  public const string Route = "/Projects/AddMember/";

  [FromBody]
  [Required]
  public int ProjectId { get; set; }
  
  [FromBody]
  [Required]
  [EmailAddress]
  public string Email { get; set; } = default!;
}
