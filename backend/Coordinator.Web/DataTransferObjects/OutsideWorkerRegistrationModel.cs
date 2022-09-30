using Coordinator.Web.Data.Entities;

namespace Coordinator.Web.DataTransferObjects;

public class OutsideWorkerRegistrationModel
{
    public WorkerType Type { get; set; }

    public string? Url { get; set; }
}