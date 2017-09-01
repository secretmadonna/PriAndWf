using System;
using PriAndWf.Domain.DomainEvent.DomainEventHandler;
using PriAndWf.Domain.EventHandler.Event;

namespace PriAndWf.Domain.EventHandler.Handler
{
    public class SendEmailEventHandler : IDomainEventHandler<RegisterEmailEvent>
    {
        public SendEmailEventHandler() { }

        public void HandleEvent(RegisterEmailEvent e)
        {
            throw new NotImplementedException();
        }
    }
}
