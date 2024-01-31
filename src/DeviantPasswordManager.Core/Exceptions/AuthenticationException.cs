namespace DeviantPasswordManager.Core.Exceptions;

public class AuthenticationException : Exception
{
  public string[] Errors { get; set; }

  public AuthenticationException(string[] errors) : base("Register Failed!")
  {
    Errors = errors;
  }

}
