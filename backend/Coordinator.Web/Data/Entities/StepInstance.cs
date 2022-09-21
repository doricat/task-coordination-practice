namespace Coordinator.Web.Data.Entities;

public class StepInstance : Entity
{
    public IDictionary<string, object>? Argument { get; set; }

    public IDictionary<string, object>? Result { get; set; }

    public virtual Step? Step { get; set; }

    public virtual ICollection<FlowInstance>? FlowInstances { get; set; }
}