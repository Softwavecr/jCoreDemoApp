using jCoreDemoApp.Domain.Common;
using jCoreDemoApp.Domain.ValueObjects;
using System.Collections.Generic;

namespace jCoreDemoApp.Domain.Entities
{
    public class ContactList : AuditableEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Colour Colour { get; set; } = Colour.White;

        public IList<ContactItem> Items { get; private set; } = new List<ContactItem>();
    }
}
