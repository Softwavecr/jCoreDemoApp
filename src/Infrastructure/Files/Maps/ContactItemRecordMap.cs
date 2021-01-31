using jCoreDemoApp.Application.ContactLists.Queries.ExportContacts;
using CsvHelper.Configuration;
using System.Globalization;

namespace jCoreDemoApp.Infrastructure.Files.Maps
{
    public class ContactItemRecordMap : ClassMap<ContactItemRecord>
    {
        public ContactItemRecordMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
        }
    }
}
