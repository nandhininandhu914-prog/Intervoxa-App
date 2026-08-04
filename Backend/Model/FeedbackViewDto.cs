namespace Intervoxa_application.Model
{
    public class FeedbackViewDto
    {
        public int FeedId { get; set; }

        public string CandidateName { get; set; }

        public string InterviewerName { get; set; }

        public string InterviewTitle { get; set; }

        public string Round { get; set; }

        public DateTime InterviewDate { get; set; }

        public int TechRate { get; set; }

        public int Communication { get; set; }

        public string? Comments { get; set; }

        public DateTime FeedbackDate { get; set; }

        public string Status { get; set; }
    }
}
