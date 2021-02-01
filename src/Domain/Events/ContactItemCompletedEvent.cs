using jCoreDemoApp.Domain.Common;
using jCoreDemoApp.Domain.Entities;

namespace jCoreDemoApp.Domain.Events
{
    public class ContactItemDeletedEvent : DomainEvent
    {
        public ContactItemDeletedEvent(ContactItem item)
        {
            Item = item;
        }

        public ContactItem Item { get; }
    }
}
