using Microsoft.AspNetCore.Identity;

namespace DeviantPasswordManager.Core.Exceptions;

public class IdentityException : Exception
{
  public IdentityException()
    : base("One or more validation failures have occurred.")
  {
    Failures = new List<string>();
  }

  public IdentityException(IEnumerable<IdentityError> failures)
    : this()
  {
    Failures.AddRange(failures
      .Select(e => e.Description)
      .Distinct());
  }

  public List<string> Failures { get; }
}
