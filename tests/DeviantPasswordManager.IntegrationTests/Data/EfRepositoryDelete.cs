using DeviantPasswordManager.Core.ProjectAggregate;
using DeviantPasswordManager.Core.IdentityAggregate;
using Xunit;

namespace DeviantPasswordManager.IntegrationTests.Data;

public class EfRepositoryDelete : BaseEfRepoTestFixture
{
  [Fact]
  public async Task DeletesItemAfterAddingIt()
  {
    // add a Project
    var testProjectName = "testProject";
    var repository = GetRepository();
    var newUser = new User(Guid.NewGuid().ToString(), "test@email.com", "secret");
    var project = new Project(testProjectName, newUser.Id);
    await repository.AddAsync(project);

    // delete the item
    await repository.DeleteAsync(project);

    // verify it's no longer there
    Assert.DoesNotContain(await repository.ListAsync(),
        Project => Project.Name == testProjectName);
  }
}
