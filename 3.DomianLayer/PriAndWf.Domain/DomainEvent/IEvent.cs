using System;

namespace PriAndWf.Domain.DomainEvent
{
    /// <summary>
    /// 继承于该接口的类型是事件
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// 事件源
        /// </summary>
        object EventSource { get; }

        /// <summary>
        /// 事件发生事件
        /// </summary>
        DateTime EventTime { get; }
    }
}
