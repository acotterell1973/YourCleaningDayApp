using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using YourCleaningDayApp.Extensions;

namespace YourCleaningDayApp.ViewModels
{
    [JsonObject(MemberSerialization.OptOut)]
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        private string _phoneNumber;
        [Required(ErrorMessage = "Phone number is required.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber
        {
            get { return _phoneNumber.FormatPhoneNumber(); }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                _phoneNumber = value.CleanPhoneNumber();
            }
        }

        [DataType(DataType.EmailAddress)]
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
