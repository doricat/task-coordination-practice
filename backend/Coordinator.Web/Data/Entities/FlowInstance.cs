namespace Coordinator.Web.Data.Entities;

public class FlowInstance : Entity
{
    public long TemplateId { get; set; }

    public long CurrentStepInstanceId { get; set; }

    public bool Completed { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public virtual FlowTemplate? Template { get; set; }

    public virtual StepInstance? CurrentStep { get; set; }
}