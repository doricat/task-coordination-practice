namespace Coordinator.Web.Data.Entities;

public class Step : Entity
{
    public long WorkerId { get; set; }

    public int Index { get; set; }

    public string? Name { get; set; }

    public int? Timeout { get; set; }

    public int? MaxRetries { get; set; }

    public StepFlag Flag { get; set; }

    public virtual Worker? Worker { get; set; }

    public virtual ICollection<StepInTemplate>? Templates { get; set; }

    public virtual ICollection<StepInstance>? Instances { get; set; }
}