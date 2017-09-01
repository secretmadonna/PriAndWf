using PriAndWf.Domain.DomainEvent.DomainEventHandler;
using System;
using System.Collections.Generic;

namespace PriAndWf.Domain.DomainEvent.DomainEventAggregator
{
    /// <summary>
    /// 继承于该接口的类型是领域事件聚合器
    /// </summary>
    public interface IDomainEventAggregator
    {
        #region 订阅
        IDisposable Subscribe<T>(IDomainEventHandler<T> domainEventHandler) where T : class, IDomainEvent;
        IDisposable Subscribe<T>(IEnumerable<IDomainEventHandler<T>> domainEventHandlers) where T : class, IDomainEvent;
        IDisposable Subscribe<T>(params IDomainEventHandler<T>[] domainEventHandlers) where T : class, IDomainEvent;
        IDisposable Subscribe<T>(Action<T> domainEventHandlerFunc) where T : class, IDomainEvent;
        IDisposable Subscribe<T>(IEnumerable<Func<T, bool>> domainEventHandlerFuncs) where T : class, IDomainEvent;
        IDisposable Subscribe<T>(params Func<T, bool>[] domainEventHandlerFuncs) where T : class, IDomainEvent;
        #endregion

        #region 取消订阅
        void UnSubscribe<T>(IDomainEventHandler<T> domainEventHandler) where T : class, IDomainEvent;
        void UnSubscribe<T>(IEnumerable<IDomainEventHandler<T>> domainEventHandlers) where T : class, IDomainEvent;
        void UnSubscribe<T>(params IDomainEventHandler<T>[] domainEventHandlers) where T : class, IDomainEvent;
        void UnSubscribe<T>(Action<T> domainEventHandlerFunc) where T : class, IDomainEvent;
        void UnSubscribe<T>(IEnumerable<Func<T, bool>> domainEventHandlerFuncs) where T : class, IDomainEvent;
        void UnSubscribe<T>(params Func<T, bool>[] domainEventHandlerFuncs) where T : class, IDomainEvent;
        void UnsubscribeAll<T>() where T : class, IDomainEvent;
        void UnsubscribeAll();
        #endregion

        #region 获取已订阅的领域事件处理器
        IEnumerable<IDomainEventHandler<T>> Subscribed<T>() where T : class, IDomainEvent;
        #endregion

        #region 发布
        void Publish<T>(T domainEvent) where T : class, IDomainEvent;
        void Publish<T>(T domainEvent, Action<T, bool, Exception> callback, TimeSpan? timeout = null) where T : class, IDomainEvent;
        #endregion
    }
}
