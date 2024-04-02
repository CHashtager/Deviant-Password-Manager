using Microsoft.AspNetCore.Mvc;

namespace DeviantPasswordManager.Web.Projects;

public class UpdateProjectResponse
{
  public UpdateProjectResponse(int id, string name)
  {
    Id = id;
    Name = name;
  }

  public int Id { get; set; }
  public string Name { get; set; }
}
