namespace Coordinator.Web.Data.Entities;

public class StepInTemplate
{
    public long TemplateId { get; set; }

    public long StepId { get; set; }

    public virtual FlowTemplate? Template { get; set; }

    public virtual Step? Step { get; set; }
}