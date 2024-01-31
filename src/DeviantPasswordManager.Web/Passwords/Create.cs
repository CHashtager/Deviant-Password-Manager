using Ardalis.Result;
using DeviantPasswordManager.UseCases.Passwords.Create;
using FastEndpoints;
using MediatR;

namespace DeviantPasswordManager.Web.Passwords;

public class Create(IMediator mediator) : Endpoint<CreatePasswordRequest>
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
      await SendAsync(result.Errors.FirstOrDefault()!, 404, cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      await SendNoContentAsync(cancellationToken);
    }
  }
}
