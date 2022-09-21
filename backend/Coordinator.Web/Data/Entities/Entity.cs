using Coordinator.Web.Infrastructure;

namespace Coordinator.Web.Data.Entities;

public abstract class Entity
{
    public long Id { get; private set; }

    public virtual void GenerateNewId(IIdGenerator generator)
    {
        Id = generator.Generate();
    }
}