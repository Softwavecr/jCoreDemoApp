using jCoreDemoApp.Domain.Common;
using jCoreDemoApp.Domain.Entities;

namespace jCoreDemoApp.Domain.Events
{
    public class ContactCreatedEvent : DomainEvent
    {
        public ContactCreatedEvent(Contact item)
        {
            Item = item;
        }

        public Contact Item { get; }
    }
}
