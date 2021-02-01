using jCoreDemoApp.Domain.Common;
using jCoreDemoApp.Domain.Entities;

namespace jCoreDemoApp.Domain.Events
{
    public class ContactDeletedEvent : DomainEvent
    {
        public ContactDeletedEvent(Contact item)
        {
            Item = item;
        }

        public Contact Item { get; }
    }
}
