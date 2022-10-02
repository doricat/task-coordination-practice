using Coordinator.Web.Data.Entities;

namespace Coordinator.Web.WorkerServices;

public interface IWorker
{
    WorkerType WorkerType { get; }

    Task ExecuteAsync(long instanceId);
}