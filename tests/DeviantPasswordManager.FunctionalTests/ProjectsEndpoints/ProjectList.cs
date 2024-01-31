using Ardalis.HttpClientTestExtensions;
using DeviantPasswordManager.Infrastructure.Data;
using DeviantPasswordManager.Web.Projects;
using Xunit;

namespace DeviantPasswordManager.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class ProjectList(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client = factory.CreateClient();

  [Fact]
  public async Task ReturnsTwoProjects()
  {
    var result = await _client.GetAndDeserializeAsync<ListProjectsResponse>("/Projects");

    Assert.Equal(2, result.Projects.Count);
    Assert.Contains(result.Projects, i => i.Name == SeedData.Project1.Name);
    Assert.Contains(result.Projects, i => i.Name == SeedData.Project2.Name);
  }
}
