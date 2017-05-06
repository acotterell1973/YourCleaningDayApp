using System;
using System.ComponentModel.DataAnnotations;

namespace YourCleaningDayApp.Data.Users
{
    public class ApplicationUser
    {
        [Key]
        [Required]
        public int UserId { get; set; }
        [Required]
        [MaxLength(128)]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        public string DisplayName { get; set; }

        public string Notes { get; set; }
        [Required]
        public int Type { get; set; }
        [Required]
        public int Flags { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime LastModifiedDate { get; set; }
    }
}
