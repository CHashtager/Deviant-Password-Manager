using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DeviantPasswordManager.Web.Passwords;

public class GetPasswordByIdRequest
{
  public const string Route = "/Passwords/GetById/";

  [FromQuery]
  [Required]
  public int PasswordId { get; set; }
  
  [FromQuery]
  [Required]
  public int ProjectId { get; set; }

}
