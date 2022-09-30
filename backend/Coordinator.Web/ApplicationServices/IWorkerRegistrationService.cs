using Coordinator.Web.DataTransferObjects;

namespace Coordinator.Web.ApplicationServices;

public interface IWorkerRegistrationService
{
    Task<string> Register(OutsideWorkerRegistrationModel model);

    Task Cancel(string id);
}