﻿using FastEndpoints;
using Ardalis.Result;
using MediatR;
using DeviantPasswordManager.UseCases.Projects.Delete;

namespace DeviantPasswordManager.Web.Projects;

public class Delete(IMediator mediator)
  : Endpoint<DeleteProjectRequest>
{
  public override void Configure()
  {
    Delete(DeleteProjectRequest.Route);
    Description(b => 
        b.Accepts<DeleteProjectRequest>().
          Produces(204).
          Produces(401).
          Produces(403).
          Produces(404),
      clearDefaults: true);
  }

  public override async Task HandleAsync(
    DeleteProjectRequest request,
    CancellationToken cancellationToken)
  {
    var command = new DeleteProjectCommand(request.ProjectId);

    var result = await mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      await SendNoContentAsync(cancellationToken);
    };
  }
}
