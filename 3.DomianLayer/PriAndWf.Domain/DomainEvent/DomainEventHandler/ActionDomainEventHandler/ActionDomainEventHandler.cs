using PriAndWf.Domain.DomainEvent.DomainEventHandler;
using System;

namespace PriAndWf.Domain.DomainEvent
{
    /// <summary>
    /// 表示代理给定的领域事件处理委托的领域事件处理器。
    /// </summary>
    /// <typeparam name="TEvent"></typeparam>
    internal sealed class ActionDomainEventHandler<T> : IDomainEventHandler<T> where T : IDomainEvent
    {
        private readonly Action<T> actionDomainEventHandler;


        public ActionDomainEventHandler(Action<T> actionDomainEventHandler)
        {
            this.actionDomainEventHandler = actionDomainEventHandler;
        }


        public void HandleEvent(T e)
        {
            this.actionDomainEventHandler(e);
        }


        /// <summary>
        /// 获取一个<see cref="Boolean"/>值，该值表示当前对象是否与给定的类型相同的另一对象相等。
        /// </summary>
        /// <param name="other">需要比较的与当前对象类型相同的另一对象。</param>
        /// <returns>如果两者相等，则返回true，否则返回false。</returns>
        public override bool Equals(object other)
        {
            if (ReferenceEquals(this, other))
                return true;
            if ((object)other == (object)null)
                return false;
            var otherAction = other as ActionDomainEventHandler<T>;
            if ((object)otherAction == (object)null)
                return false;
            // 使用Delegate.Equals方法判定两个委托是否是代理的同一方法。
            return Delegate.Equals(this.actionDomainEventHandler, otherAction.actionDomainEventHandler);
        }

        public override int GetHashCode()
        {
            return this.actionDomainEventHandler.GetHashCode();
        }
    }
}
