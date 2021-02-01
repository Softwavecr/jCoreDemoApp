namespace jCoreDemoApp.Domain.Entities
{
    public class Phone
    {
        public string id { get; set; }
        public string userId { get; set; }
        public string createdAt { get; set; } 
        public int IMEI { get; set; }
        public bool Blacklist { get; set; } 
    }
}
