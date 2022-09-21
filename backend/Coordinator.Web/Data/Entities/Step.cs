namespace Coordinator.Web.Data.Entities;

public class Step : Entity
{
    public int Index { get; set; }

    public string? Name { get; set; }

    public virtual Worker? Worker { get; set; }

    public virtual ICollection<StepInstance>? Instances { get; set; }
}