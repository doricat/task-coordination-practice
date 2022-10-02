namespace Coordinator.Web.Data.Entities;

public class FlowInstance : Entity
{
    public long TemplateId { get; set; }

    public long CurrentStepInstanceId { get; set; }

    public FlowInstanceState State { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual FlowTemplate? Template { get; set; }

    public virtual StepInstance? CurrentStep { get; set; }

    public void MoveNext()
    {
        throw new NotImplementedException();
    }
}