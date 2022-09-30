using Coordinator.Web.Data.Entities;

namespace Coordinator.Web.DataTransferObjects;

public class InsideWorkerRegistrationModel
{
    public WorkerType Type { get; set; }

    public IWorker? Worker { get; set; }
}