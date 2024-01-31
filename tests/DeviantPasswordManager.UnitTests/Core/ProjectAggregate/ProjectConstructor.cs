using DeviantPasswordManager.Core.IdentityAggregate;
using DeviantPasswordManager.Core.ProjectAggregate;
using Xunit;

namespace DeviantPasswordManager.UnitTests.Core.ProjectAggregate;

public class ProjectConstructor
{
  private readonly string _testName = "test name";
  private readonly string _testUserId = Guid.Empty.ToString();
  private readonly string _testEmail = "test@name.com";
  private readonly string _testPassPhrase = "test pass phrase";
  private Project? _testProject;

  private Project CreateProject()
  {
    var user = new User(_testUserId, _testEmail, _testPassPhrase);
    return new Project(_testName, user.Id);
  }

  [Fact]
  public void InitializesProject()
  {
    _testProject = CreateProject();

    Assert.Equal(_testName, _testProject.Name);
  }
}
