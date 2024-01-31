using DeviantPasswordManager.Core.IdentityAggregate;
using DeviantPasswordManager.Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DeviantPasswordManager.IntegrationTests.Data;

public class EfRepositoryUpdate : BaseEfRepoTestFixture
{
  [Fact]
  public async Task UpdatesItemAfterAddingIt()
  {
    // add a Project
    var repository = GetRepository();
    var initialName = Guid.NewGuid().ToString();
    var newUser = new User(Guid.NewGuid().ToString(), "test@email.com", "secret");
    var Project = new Project(initialName, newUser.Id);

    await repository.AddAsync(Project);

    // detach the item so we get a different instance
    _dbContext.Entry(Project).State = EntityState.Detached;

    // fetch the item and update its title
    var newProject = (await repository.ListAsync())
        .FirstOrDefault(Project => Project.Name == initialName);
    if (newProject == null)
    {
      Assert.NotNull(newProject);
      return;
    }
    Assert.NotSame(Project, newProject);
    var newName = Guid.NewGuid().ToString();
    newProject.UpdateName(newName);

    // Update the item
    await repository.UpdateAsync(newProject);

    // Fetch the updated item
    var updatedItem = (await repository.ListAsync())
        .FirstOrDefault(Project => Project.Name == newName);

    Assert.NotNull(updatedItem);
    Assert.NotEqual(Project.Name, updatedItem?.Name);
    Assert.Equal(newProject.Id, updatedItem?.Id);
  }
}
