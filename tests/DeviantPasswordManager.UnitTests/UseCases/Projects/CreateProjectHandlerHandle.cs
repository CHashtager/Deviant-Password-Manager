using Ardalis.SharedKernel;
using DeviantPasswordManager.Core.IdentityAggregate;
using DeviantPasswordManager.Core.IdentityAggregate.Specifications;
using DeviantPasswordManager.Core.Interfaces;
using DeviantPasswordManager.Core.ProjectAggregate;
using DeviantPasswordManager.UseCases.Projects.Create;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace DeviantPasswordManager.UnitTests.UseCases.Projects;

public class CreateProjectHandlerHandle
{
  private readonly string _testName = "test name";
  private readonly string _testUserId = Guid.Empty.ToString();
  private readonly string _testEmail = "test@name.com";
  private readonly string _testPassPhrase = "test pass phrase";
  private readonly User _testUser;
  private readonly IRepository<Project> _repository = Substitute.For<IRepository<Project>>();
  private readonly ICurrentUserService _currentUserService = Substitute.For<ICurrentUserService>();
  private readonly IReadRepository<User> _userRepository = Substitute.For<IReadRepository<User>>();
  private readonly CreateProjectHandler _handler;


  public CreateProjectHandlerHandle()
  {
    _currentUserService.UserId.Returns(_testUserId);
    _testUser = new User(_testUserId, _testEmail, _testPassPhrase);

    _userRepository.FirstOrDefaultAsync(Arg.Any<UserByIdentityIdSpec>(), Arg.Any<CancellationToken>())!
      .Returns(Task.FromResult(_testUser));
    
    _handler = new CreateProjectHandler(_repository, _currentUserService, _userRepository);
    
  }

  private Project CreateProject(User user)
  {
    return new Project(_testName, user.Id, null);
  }

  [Fact]
  public async Task ReturnsSuccessGivenValidName()
  {

    
    _repository.AddAsync(Arg.Any<Project>(), Arg.Any<CancellationToken>())
      .Returns(Task.FromResult(CreateProject(_testUser)));
    var result = await _handler.Handle(new CreateProjectCommand(_testName, null), CancellationToken.None);

    result.IsSuccess.Should().BeTrue();
  }
}
