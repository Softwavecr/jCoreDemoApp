using jCoreDemoApp.Domain.Common;
using jCoreDemoApp.Domain.Entities;

namespace jCoreDemoApp.Domain.Events
{
    public class ContactItemCreatedEvent : DomainEvent
    {
        public ContactItemCreatedEvent(ContactItem item)
        {
            Item = item;
        }

        public ContactItem Item { get; }
    }
}
