using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intervoxa_application.Model
{
    public class FeedbackModel
    {
        [Key]
        public int FeedId { get; set; }

        public int ScheduleId { get; set; }

        [ForeignKey("ScheduleId")]
        public ScheduleModel ScheduleInterview { get; set; }

        [Required]
        public int TechRate { get; set; }

        [Required]
        public int Communication { get; set; }

        public string? Comments { get; set; }

        public DateTime FeedbackDate { get; set; } = DateTime.Now;
    }
}
