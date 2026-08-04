using System.ComponentModel.DataAnnotations;

namespace Intervoxa_application.Model
{
    public class Feedbackdto
    {
        public int ScheduleId { get; set; }

        [Required]
        public int TechRate { get; set; }

        [Required]
        public int Communication { get; set; }

        public string? Comments { get; set; }
    }
}
