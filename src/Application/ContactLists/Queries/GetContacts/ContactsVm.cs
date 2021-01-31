using System.Collections.Generic;

namespace jCoreDemoApp.Application.ContactLists.Queries.GetContacts
{
    public class ContactsVm
    {
        public IList<PriorityLevelDto> PriorityLevels { get; set; }

        public IList<ContactListDto> Lists { get; set; }
    }
}
