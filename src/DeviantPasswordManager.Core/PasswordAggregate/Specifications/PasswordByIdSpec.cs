using Ardalis.Specification;

namespace DeviantPasswordManager.Core.PasswordAggregate.Specifications;

public class PasswordByIdSpec : Specification<Password>
{
  public PasswordByIdSpec(int passwordId)
  {
    Query
      .Where(password => password.Id == passwordId);
  }
}
