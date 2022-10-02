namespace Coordinator.Web.Repositories;

public interface IRepo
{
    IUnitOfWork UnitOfWork { get; }
}