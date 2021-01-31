using jCoreDemoApp.Application.Common.Mappings;
using jCoreDemoApp.Domain.Entities;

namespace jCoreDemoApp.Application.ContactLists.Queries.ExportContacts
{
    public class ContactItemRecord : IMapFrom<ContactItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
