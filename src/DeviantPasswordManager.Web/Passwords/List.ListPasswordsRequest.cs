using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DeviantPasswordManager.Web.Passwords;

public class ListPasswordsRequest
{
  public const string Route = "/Passwords/List/";
  
  [FromQuery]
  [Required]
  public int ProjectId { get; set; }
  
}
