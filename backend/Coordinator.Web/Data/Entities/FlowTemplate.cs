namespace Coordinator.Web.Data.Entities;

public class FlowTemplate : Entity
{
    public string? Name { get; set; }

    public bool[][]? Arcs { get; set; }

    public virtual ICollection<StepInTemplate>? Steps { get; set; }

    public virtual ICollection<FlowInstance>? Instances { get; set; }
}