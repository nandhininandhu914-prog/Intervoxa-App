using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intervoxa_application.Model
{
    public class ScheduleModel
    {
        [Key]
        public int ScheduleId {  get; set; }

        public int InterviewId {  get; set; }

        [ForeignKey("InterviewId")]
        public InterviewModel Interviewer { get; set; }

        public int CandidateId {  get; set; }

        [ForeignKey("CandidateId")]
        public CandidateModel Candidate { get; set; }

        public string InterviewTitle {  get; set; }

        [Required]
        public string Round {  get; set; }

        [Required]
        public DateTime InterviewDate { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Required]
        public string MeetingType {  get; set; }

        public string ? MeetingLink {  get; set; }

        [Required]
        public string Status {  get; set; }

        public FeedbackModel? Feedback { get; set; }//one to one


    }
}
