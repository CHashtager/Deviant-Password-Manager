using DeviantPasswordManager.UseCases.Passwords.List;
using FastEndpoints;
using MediatR;

namespace DeviantPasswordManager.Web.Passwords;

public class List(IMediator mediator) : Endpoint<ListPasswordsRequest>
{
  public override void Configure()
  {
    Get(ListPasswordsRequest.Route);
  }

  public override async Task HandleAsync(
    ListPasswordsRequest request,
    CancellationToken cancellationToken)
  {
    var result = await mediator.Send(new ListPasswordsQuery(request.ProjectId));

    if (result.IsSuccess)
    {
      Response = new ListPasswordsResponse()
      {
        Passwords = result.Value.Select(p => new PasswordRecord(p.Id, p.Name, p.Username, p.Password, p.Url)).ToList()
      };
    }
  }
}
