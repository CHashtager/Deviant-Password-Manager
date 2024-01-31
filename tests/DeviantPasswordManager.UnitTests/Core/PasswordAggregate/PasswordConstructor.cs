using DeviantPasswordManager.Core.IdentityAggregate;
using DeviantPasswordManager.Core.PasswordAggregate;
using DeviantPasswordManager.Core.ProjectAggregate;
using Xunit;

namespace DeviantPasswordManager.UnitTests.Core.PasswordAggregate;

public class PasswordConstructor
{
  private readonly string _testProjectName = "test name";
  private readonly string _testUserId = Guid.Empty.ToString();
  private readonly string _testEmail = "test@name.com";
  private readonly string _testPassPhrase = "test pass phrase";
  private readonly string _testName = "test name";
  private readonly string _testUsername = "test@name.com";
  private readonly string _testEncryptedPassword = "teasdasdasd";
  private readonly string _testUrl = "test@name.com";

  private Password? _testPassword;
  
  private Password CreatePassword()
  {
    var user = new User(_testUserId, _testEmail, _testPassPhrase);
    var project = new Project(_testProjectName, user.Id);

    return new Password(_testName, _testUsername, _testEncryptedPassword, _testUrl, project.Id, user.Id);
  }
  
  [Fact]
  public void InitializesName()
  {
    _testPassword = CreatePassword();
  
    Assert.Equal(_testName, _testPassword.Name);
  }
}
