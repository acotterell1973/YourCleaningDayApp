using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourCleaningDayApp.Data.Addresses
{
    public class Address : BaseEntity
    {

        [Key]
        [Required]
        public int AddressId { get; set; }
        
        [Required]
        [MaxLength(220)]
        public string Address1 { get; set; }

        [MaxLength(120)]
        public string Address2 { get; set; }

        [MaxLength(60)]
        public string Address3 { get; set; }
        
        [Required]
        [MaxLength(120)]
        public string City { get; set; }
        
        [Required]
        [Column(TypeName = "char(2)")]
        public string StateId { get; set; }
        
        [Required]
        [MaxLength(5)]
        public int Zipcode { get; set; }

        [MaxLength(20)]
        public string GateCode { get; set; }

        [MaxLength(20)]
        public string Alarmcode { get; set; }

        public string MapUrl { get; set; }
        
    }
}
