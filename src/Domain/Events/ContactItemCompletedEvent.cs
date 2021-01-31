using jCoreDemoApp.Domain.Common;
using jCoreDemoApp.Domain.Entities;

namespace jCoreDemoApp.Domain.Events
{
    public class ContactItemCompletedEvent : DomainEvent
    {
        public ContactItemCompletedEvent(ContactItem item)
        {
            Item = item;
        }

        public ContactItem Item { get; }
    }
}
