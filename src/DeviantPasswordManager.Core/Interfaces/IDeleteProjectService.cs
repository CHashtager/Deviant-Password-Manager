using Ardalis.Result;

namespace DeviantPasswordManager.Core.Interfaces;

public interface IDeleteProjectService
{
  public Task<Result> DeleteProject(int projectId);
}
