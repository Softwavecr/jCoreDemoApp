using jCoreDemoApp.Application.Common.Mappings;
using jCoreDemoApp.Domain.Entities;

namespace jCoreDemoApp.Application.ContactLists.Queries.ExportContacts
{
    public class ContactItemRecord : IMapFrom<ContactItem>
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
        public bool Deleted { get; set; }
        public int Priority { get; set; }
    }
}
