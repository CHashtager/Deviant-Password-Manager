using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DeviantPasswordManager.Web.Projects;

public class ListProjectsRequest
{
  public const string Route = "/Projects/List/";
  
  [FromQuery]
  [Required]
  public int? ParentId { get; set; }
}
