using System.ComponentModel.DataAnnotations;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace DeviantPasswordManager.Web.Projects;

public class ListProjectsRequest
{
  public const string Route = "/Projects/List/";
  
  [QueryParam]
  [Required]
  public int? ParentId { get; set; }
}
