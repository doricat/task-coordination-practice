using Coordinator.Web.Data.Aggregates;

namespace Coordinator.Web.Repositories;

public interface IFlowInstanceRepo : IRepo
{
    Task<FlowInstanceAggregateModel?> GetAsync(long id);
}