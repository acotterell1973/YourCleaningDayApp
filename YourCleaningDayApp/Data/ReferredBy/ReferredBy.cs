using System.ComponentModel.DataAnnotations;

namespace YourCleaningDayApp.Data.ReferredBy
{
    public class ReferredBy
    {
        [Key]
        [Required]
        public int ReferedById { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
    }
}
