using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourCleaningDayApp.Data
{
    public class BaseEntity
    {
        [Required]
        [Column(Order = 97)]
        public int CreatedUserId { get; set; }
        [Required]
        [Column(Order = 98)]
        public DateTime CreatedDate { get; set; }

        [Required]
        public int ModifiededUserId { get; set; }
        [Required]
        [Column(Order = 99)]
        public DateTime? ModifiedDate { get; set; }

        [Timestamp]
        [Column(Order = 100)]
        public byte[] RowVersion { get; set; }
    }
}
