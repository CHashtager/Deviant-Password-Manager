using Microsoft.AspNetCore.Mvc;

namespace DeviantPasswordManager.Web.Projects;

public class AddProjectMemberResponse
{
  public AddProjectMemberResponse(int id, string name, List<ProjectMemberRecord> members)
  {
    Id = id;
    Name = name;
    Members = members;
  }

  public int Id { get; set; }
  public string Name { get; set; }
  public List<ProjectMemberRecord> Members { get; set; } = new();
}
