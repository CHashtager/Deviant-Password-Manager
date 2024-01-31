using FastEndpoints;
using MediatR;
using Ardalis.Result;
using DeviantPasswordManager.UseCases.Passwords.GetById;

namespace DeviantPasswordManager.Web.Passwords;

public class GetById(IMediator mediator)
  : Endpoint<GetPasswordByIdRequest, GetPasswordByIdResponse>
{
  public override void Configure()
  {
    Get(GetPasswordByIdRequest.Route);
  }

  public override async Task HandleAsync(GetPasswordByIdRequest request,
    CancellationToken cancellationToken)
  {
    var command = new GetPasswordByIdQuery(request.PasswordId, request.ProjectId);

    var result = await mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new GetPasswordByIdResponse(result.Value.Id, result.Value.Name, result.Value.Username,
        result.Value.Password, result.Value.Url);
    }
  }
}
