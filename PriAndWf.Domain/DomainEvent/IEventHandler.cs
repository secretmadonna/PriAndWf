namespace PriAndWf.Domain.DomainEvent
{
    /// <summary>
    /// 继承于该接口的类型是事件处理器
    /// </summary>
    /// <typeparam name="T">事件</typeparam>
    public interface IEventHandler<in T> where T : IEvent
    {
        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="e">需要处理的事件</param>
        void HandleEvent(T e);
    }
}
