using System;
using PriAndWf.Domain.DomainEvent.DomainEventHandler;
using PriAndWf.Domain.EventHandler.Event;

namespace PriAndWf.Domain.EventHandler.Handler
{
    public class SendShortMessageEventHandler : IDomainEventHandler<RegisterShortMessageEvent>
    {
        public SendShortMessageEventHandler() { }

        public void HandleEvent(RegisterShortMessageEvent e)
        {
            throw new NotImplementedException();
        }
    }
}
