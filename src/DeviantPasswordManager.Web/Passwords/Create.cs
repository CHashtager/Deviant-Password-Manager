using Ardalis.Result;
using DeviantPasswordManager.UseCases.Passwords.Create;
using FastEndpoints;
using MediatR;

namespace DeviantPasswordManager.Web.Passwords;

public class Create(IMediator mediator) : Endpoint<CreatePasswordRequest, CreatePasswordResponse>
{
  public override void Configure()
  {
    Post(CreatePasswordRequest.Route);
  }

  public override async Task HandleAsync(CreatePasswordRequest request, CancellationToken cancellationToken)
  {
    var command =
      new CreatePasswordCommand(request.Name, request.Username, request.Password, request.Url, request.ProjectId);

    var result = await mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync();
      return;
    }

    if (result.IsSuccess)
    {
      await SendCreatedAtAsync<GetById>(new {PasswordId = result.Value.Id}, new CreatePasswordResponse(result.Value.Id, result.Value.Name, result.Value.Username, result.Value.Password, result.Value.Url));
    }
  }
}
