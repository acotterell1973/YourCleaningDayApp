using Newtonsoft.Json;

namespace YourCleaningDayApp.ViewModels
{
    [JsonObject(MemberSerialization.OptOut)]
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
