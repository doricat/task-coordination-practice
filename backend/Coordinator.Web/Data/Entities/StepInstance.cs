namespace Coordinator.Web.Data.Entities;

public class StepInstance : Entity
{
    public long StepId { get; set; }

    public IDictionary<string, object>? Input { get; set; }

    public IDictionary<string, object>? Output { get; set; }

    public virtual Step? Step { get; set; }

    public virtual FlowInstance? FlowInstance { get; set; }
}