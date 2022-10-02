using Coordinator.Web.Data.Entities;

namespace Coordinator.Web.Data.Aggregates;

public class StepInstanceAggregateModel
{
    private readonly StepInstance _instance;

    public StepInstanceAggregateModel(StepInstance instance)
    {
        _instance = instance ?? throw new ArgumentNullException(nameof(instance));
    }

    public long Id => _instance.Id;

    public long StepId => _instance.StepId;

    public IDictionary<string, object> Input => _instance.Input ?? new Dictionary<string, object>(0);

    public IDictionary<string, object> Output => _instance.Output ?? new Dictionary<string, object>(0);

    public void SetOutput(IDictionary<string, object> value)
    {
        _instance.Output = value;
    }
}