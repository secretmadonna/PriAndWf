using System;
using System.Collections.Generic;
using PriAndWf.Domain.DomainEvent.DomainEventHandler;

namespace PriAndWf.Domain.DomainEvent.DomainEventAggregator
{
    public class DomainEventAggregator : IDomainEventAggregator
    {
        #region 订阅
        public IDisposable Subscribe<T>(IDomainEventHandler<T> domainEventHandler) where T : class, IDomainEvent
        {
            throw new NotImplementedException();
        }
        public IDisposable Subscribe<T>(IEnumerable<IDomainEventHandler<T>> domainEventHandlers) where T : class, IDomainEvent
        {
            throw new NotImplementedException();
        }
        public IDisposable Subscribe<T>(params IDomainEventHandler<T>[] domainEventHandlers) where T : class, IDomainEvent
        {
            throw new NotImplementedException();
        }
        public IDisposable Subscribe<T>(Action<T> domainEventHandlerFunc) where T : class, IDomainEvent
        {
            throw new NotImplementedException();
        }
        public IDisposable Subscribe<T>(IEnumerable<Func<T, bool>> domainEventHandlerFuncs) where T : class, IDomainEvent
        {
            throw new NotImplementedException();
        }
        public IDisposable Subscribe<T>(params Func<T, bool>[] domainEventHandlerFuncs) where T : class, IDomainEvent
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 取消订阅
        public void UnSubscribe<T>(IDomainEventHandler<T> domainEventHandler) where T : class, IDomainEvent
        {
            throw new NotImplementedException();
        }
        public void UnSubscribe<T>(IEnumerable<IDomainEventHandler<T>> domainEventHandlers) where T : class, IDomainEvent
        {
            throw new NotImplementedException();
        }
        public void UnSubscribe<T>(params IDomainEventHandler<T>[] domainEventHandlers) where T : class, IDomainEvent
        {
            throw new NotImplementedException();
        }
        public void UnSubscribe<T>(Action<T> domainEventHandlerFunc) where T : class, IDomainEvent
        {
            throw new NotImplementedException();
        }
        public void UnSubscribe<T>(IEnumerable<Func<T, bool>> domainEventHandlerFuncs) where T : class, IDomainEvent
        {
            throw new NotImplementedException();
        }
        public void UnSubscribe<T>(params Func<T, bool>[] domainEventHandlerFuncs) where T : class, IDomainEvent
        {
            throw new NotImplementedException();
        }
        public void UnsubscribeAll<T>() where T : class, IDomainEvent
        {
            throw new NotImplementedException();
        }
        public void UnsubscribeAll()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 获取已订阅的领域事件处理器
        public IEnumerable<IDomainEventHandler<T>> Subscribed<T>() where T : class, IDomainEvent
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 发布
        public void Publish<T>(T domainEvent) where T : class, IDomainEvent
        {
            throw new NotImplementedException();
        }
        public void Publish<T>(T domainEvent, Action<T, bool, Exception> callback, TimeSpan? timeout = null) where T : class, IDomainEvent
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
