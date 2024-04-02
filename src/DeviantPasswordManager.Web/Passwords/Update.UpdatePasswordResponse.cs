﻿namespace DeviantPasswordManager.Web.Passwords;

public class UpdatePasswordResponse
{
  public UpdatePasswordResponse(int id, string name, string username, string password, string url)
  {
    Id = id;
    Name = name;
    Username = username;
    Password = password;
    Url = url;
  }

  public int Id { get; set; }
  public string Name { get; set; }
  public string Username { get; set; }
  public string Password { get; set; }
  public string Url { get; set; }
}
