using Ardalis.SharedKernel;
using DeviantPasswordManager.Core.ProjectAggregate;
using DeviantPasswordManager.Core.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace DeviantPasswordManager.UnitTests.Core.Services;

public class DeleteProjectService_DeleteProject
{
  private readonly IRepository<Project> _repository = Substitute.For<IRepository<Project>>();
  private readonly IMediator _mediator = Substitute.For<IMediator>();
  private readonly ILogger<DeleteProjectService> _logger = Substitute.For<ILogger<DeleteProjectService>>();

  private readonly DeleteProjectService _service;

  public DeleteProjectService_DeleteProject()
  {
    _service = new DeleteProjectService(_repository, _mediator, _logger);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenCantFindProject()
  {
    var result = await _service.DeleteProject(0);

    Assert.Equal(Ardalis.Result.ResultStatus.NotFound, result.Status);
  }
}
