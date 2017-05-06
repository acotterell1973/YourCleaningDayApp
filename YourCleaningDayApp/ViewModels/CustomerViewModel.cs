using Newtonsoft.Json;

namespace YourCleaningDayApp.ViewModels
{
    [JsonObject(MemberSerialization.OptOut)]
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }

        public string MapUrl { get; set; }

        public string MemberDate { get; set; }
    
    }
}
