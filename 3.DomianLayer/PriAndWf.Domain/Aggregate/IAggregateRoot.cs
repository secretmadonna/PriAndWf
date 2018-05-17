using PriAndWf.Domain.Entity;

namespace PriAndWf.Domain.Aggregate
{
    /// <summary>
    /// 继承于该接口的类型是聚合根类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAggregateRoot<T> : IEntity<T>
    {

    }
    /// <summary>
    /// 继承于该接口的类型是聚合根类型（默认：int）
    /// </summary>
    public interface IAggregateRoot : IAggregateRoot<int>, IEntity
    {

    }
}
