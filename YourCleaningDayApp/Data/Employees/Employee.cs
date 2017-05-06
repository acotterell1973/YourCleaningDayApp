using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YourCleaningDayApp.Data.Tenants;
using YourCleaningDayApp.Data.Users;

namespace YourCleaningDayApp.Data.Employees
{
    public class Employee
    {

        #region Properties

        [Required]
        public int TenantId { get; set; }
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public int SalutationId { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public int CreatedUserId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public int ModifiededUserId { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }

        public byte[] RowVersion { get; set; }
        #endregion

        #region Related Properties

        [ForeignKey("TenantId")]
        public virtual Tenant Business { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        #endregion
    }

}

