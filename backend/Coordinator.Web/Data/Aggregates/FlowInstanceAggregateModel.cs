using Coordinator.Web.Data.Entities;

namespace Coordinator.Web.Data.Aggregates;

public class FlowInstanceAggregateModel
{
    private readonly FlowInstance _instance;

    public FlowInstanceAggregateModel(FlowInstance instance)
    {
        _instance = instance ?? throw new ArgumentNullException(nameof(instance));
    }

    public long Id => _instance.Id;

    public long TemplateId => _instance.TemplateId;

    public long CurrentStepInstanceId => _instance.CurrentStepInstanceId;

    public FlowInstanceState State => _instance.State;

    public DateTime CreatedAt => _instance.CreatedAt;

    public DateTime? UpdatedAt => _instance.UpdatedAt;

    public virtual StepInstanceAggregateModel CurrentStep
    {
        get
        {
            if (_instance.CurrentStep == null)
            {
                throw new ArgumentNullException(nameof(_instance.CurrentStep));
            }

            return new StepInstanceAggregateModel(_instance.CurrentStep);
        }
    }

    public void MoveNext() => _instance.MoveNext();
}