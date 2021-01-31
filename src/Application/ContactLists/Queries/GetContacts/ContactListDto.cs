using jCoreDemoApp.Application.Common.Mappings;
using jCoreDemoApp.Domain.Entities;
using System.Collections.Generic;

namespace jCoreDemoApp.Application.ContactLists.Queries.GetContacts
{
    public class ContactListDto : IMapFrom<ContactList>
    {
        public ContactListDto()
        {
            Items = new List<ContactItemDto>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Colour { get; set; }

        public IList<ContactItemDto> Items { get; set; }
    }
}
