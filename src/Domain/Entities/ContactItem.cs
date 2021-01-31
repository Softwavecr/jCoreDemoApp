using jCoreDemoApp.Domain.Common;
using jCoreDemoApp.Domain.Enums;
using jCoreDemoApp.Domain.Events;
using System;
using System.Collections.Generic;

namespace jCoreDemoApp.Domain.Entities
{
    public class ContactItem : AuditableEntity, IHasDomainEvent
    {
        public int Id { get; set; }
        public ContactList List { get; set; }
        public int ListId { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        object ProfileImage { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public string PhoneNumberWork { get; set; }
        public string PhoneNumberPersonal { get; set; }
        public string Address { get; set; }

        public PriorityLevel Priority { get; set; }

        public DateTime? Reminder { get; set; }

        private bool _done;
        public bool Done
        {
            get => _done;
            set
            {
                if (value == true && _done == false)
                {
                    DomainEvents.Add(new ContactItemCompletedEvent(this));
                }

                _done = value;
            }
        }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
