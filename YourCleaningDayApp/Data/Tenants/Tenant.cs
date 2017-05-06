using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YourCleaningDayApp.Data.Employees;


namespace YourCleaningDayApp.Data.Tenants
{
    /// <summary>
    /// The tenant refers to a business that's using this service
    /// the tentant will have employees which is represented by the Employee entity
    /// </summary>
    public class Tenant
    {
        [Required]
        public int TenantId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }

        [Required]
        public int CreatedUserId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public int ModifiededUserId { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }

        public byte[] RowVersion { get; set; }

        #region Related Properties
        public virtual List<Employee> Employees { get; set; }

        #endregion
    }
}
