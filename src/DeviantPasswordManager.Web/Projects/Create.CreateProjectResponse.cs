﻿using Microsoft.AspNetCore.Mvc;

namespace DeviantPasswordManager.Web.Projects;

public class CreateProjectResponse
{
  public CreateProjectResponse(int id, string name)
  {
    Id = id;
    Name = name;
  }

  public int Id { get; set; }
  public string Name { get; set; }
}
