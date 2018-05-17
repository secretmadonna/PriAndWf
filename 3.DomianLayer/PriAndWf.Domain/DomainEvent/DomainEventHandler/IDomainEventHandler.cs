using PriAndWf.Domain.Entity;

namespace PriAndWf.Domain.DomainEvent.DomainEventHandler
{
    /// <summary>
    /// 继承于该接口的类型是领域事件处理器
    /// </summary>
    public interface IDomainEventHandler<in T> : IEventHandler<T> where T : IDomainEvent
    {

    }
}
