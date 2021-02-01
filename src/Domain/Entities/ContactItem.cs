using jCoreDemoApp.Domain.Common;
using jCoreDemoApp.Domain.Enums;
using jCoreDemoApp.Domain.Events;
using System;
using System.Collections.Generic;

namespace jCoreDemoApp.Domain.Entities
{
    public class Contact : AuditableEntity, IHasDomainEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public byte[] ProfileImage { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public string PhoneNumberWork { get; set; }
        public string PhoneNumberPersonal { get; set; }
        public string Address { get; set; }
        public PriorityLevel Priority { get; set; }
        public DateTime? Reminder { get; set; }
        private bool _deleted;
        public bool Deleted
        {
            get => _deleted;
            set
            {
                if (value == true && _deleted == false)
                {                    
                    DomainEvents.Add(new ContactDeletedEvent(this));
                }

                _deleted = value;
            }
        }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
