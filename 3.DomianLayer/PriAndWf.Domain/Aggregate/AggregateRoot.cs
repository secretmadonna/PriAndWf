using PriAndWf.Domain.Entity;

namespace PriAndWf.Domain.Aggregate
{
    public class AggregateRoot<T> : Entity<T>, IAggregateRoot<T>
    {

    }
    public class AggregateRoot : AggregateRoot<int>, IAggregateRoot
    {

    }
}
