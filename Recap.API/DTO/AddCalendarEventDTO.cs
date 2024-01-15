using System.ComponentModel.DataAnnotations;

namespace Recap.API.DTO
{
    public class AddCalendarEventDTO
    {
        [MaxLength(100)]
        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
    }
}
