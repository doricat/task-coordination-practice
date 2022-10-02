namespace Coordinator.Web.Repositories;

public interface IUnitOfWork
{
    Task CommitAsync();
}