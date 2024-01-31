using Ardalis.HttpClientTestExtensions;
using DeviantPasswordManager.Infrastructure.Data;
using DeviantPasswordManager.Web.Projects;
using Xunit;

namespace DeviantPasswordManager.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class ProjectGetById(CustomWebApplicationFactory<Program> factory)
  : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client = factory.CreateClient();

  [Fact]
  public async Task ReturnsSeedProjectGivenId1()
  {
    var result =
      await _client.GetAndDeserializeAsync<ProjectRecord>(
        $"/api/Projects?{Utilities.GetQueryString(new { ProjectId = 1 })}");

    Assert.Equal(1, result.Id);
    Assert.Equal(SeedData.Project1.Name, result.Name);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenId1000()
  {
    string route = $"/api/Projects?{Utilities.GetQueryString(new { ProjectId = 1000 })}";
    _ = await _client.GetAndEnsureNotFoundAsync(route);
  }
}
