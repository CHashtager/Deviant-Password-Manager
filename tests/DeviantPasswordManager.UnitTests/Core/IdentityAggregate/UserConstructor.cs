using DeviantPasswordManager.Core.IdentityAggregate;
using Xunit;

namespace DeviantPasswordManager.UnitTests.Core.IdentityAggregate;

public class UserConstructor
{
  private readonly string _testUserId = Guid.Empty.ToString();
  private readonly string _testEmail = "test@name.com";
  private readonly string _testPassPhrase = "test pass phrase";
  private User? _testIdentity;

  private User CreateUser()
  {
    return new User(_testUserId, _testEmail, _testPassPhrase);
  }

  [Fact]
  public void InitializesUser()
  {
    _testIdentity = CreateUser();

    Assert.Equal(_testUserId, _testIdentity.UserId);
    Assert.Equal(_testEmail, _testIdentity.Email);
    Assert.Equal(_testPassPhrase, _testIdentity.PassPhrase);
  }
}
