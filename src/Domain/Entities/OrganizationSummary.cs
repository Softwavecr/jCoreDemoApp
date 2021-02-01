using System.Collections.Generic;

namespace jCoreDemoApp.Domain.Entities
{
    public class OrganizationSummary
    {
        public string id { get; set; }
        public string name { get; set; }
        public int blacklistTotal { get; set; }
        public int totalCount { get; set; }
        public List<UserPhoneGroup> users { get; set; }
    }   
}

