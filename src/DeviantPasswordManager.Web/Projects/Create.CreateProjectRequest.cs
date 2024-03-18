using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DeviantPasswordManager.Web.Projects;

public class CreateProjectRequest
{
  public const string Route = "/Projects/Create/";

  [FromBody] [Required] public string Name { get; set; } = default!;
  [FromBody] public int? ParentId { get; set; }
}
