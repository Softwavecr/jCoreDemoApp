namespace jCoreDemoApp.Application.ContactLists.Queries.ExportContacts
{
    public class ExportContactsVm
    {
        public string FileName { get; set; }

        public string ContentType { get; set; }

        public byte[] Content { get; set; }
    }
}