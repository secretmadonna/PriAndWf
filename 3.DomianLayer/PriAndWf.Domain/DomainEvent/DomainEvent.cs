using System;
using PriAndWf.Domain.Entity;

namespace PriAndWf.Domain.DomainEvent
{
    [Serializable]
    public abstract class DomainEvent : IDomainEvent
    {
        private readonly object eventSource;
        private DateTime eventTime = DateTime.UtcNow;


        public DomainEvent() { }
        public DomainEvent(object eventSource)
        {
            this.eventSource = eventSource;
        }


        public object EventSource
        {
            get { return this.eventSource; }
        }

        public DateTime EventTime
        {
            get { return this.eventTime; }
        }
    }
}
