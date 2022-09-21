namespace Coordinator.Web.Data.Entities;

[Flags]
public enum StepFlag
{
    None = 0,
    Pausing = 1,
    Continuing = 2,
    Canceling = 4
}