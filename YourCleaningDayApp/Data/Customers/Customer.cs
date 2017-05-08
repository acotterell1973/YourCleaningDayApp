using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YourCleaningDayApp.Data.Addresses;

namespace YourCleaningDayApp.Data.Customers
{
    public class Customer : BaseEntity
    {
        [Key]
        [Required]
        [Column(Order = 1)]
        public int CustomerId { get; set; }
        
        [Required]
        [Column(Order = 2)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Column(Order = 3)]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Column(Order = 4)]
        [MaxLength(120)]
        public string PrimaryEmailAddress { get; set; }

        [Required]
        [Column(Order = 5)]
        [MaxLength(10)]
        public string PrimaryPhoneNumber { get; set; }

        [Required]
        [Column(Order = 6, TypeName = "char(2)")]
        [MaxLength(2)]
        public string Gender { get; set; }

        #region Related Properties
        
        [ForeignKey("ReferredById")]
        public ReferredBy.ReferredBy ReferedBy { get; set; }

        [Required]
        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }

        public bool Active { get; set; } = true;

        #endregion

    }
}
