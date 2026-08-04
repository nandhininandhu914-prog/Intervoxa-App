using System;
using System.ComponentModel.DataAnnotations;

namespace Intervoxa_application.Model
{
    public class Scheduledto
    {
        public string InterviewTitle {  get; set; }

        public int CandidateId {  get; set; }

        public int InterviewId { get; set; }

        public string Round { get; set; }

        public DateTime InterviewDate { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public string MeetingType { get; set; }

        public string? MeetingLink { get; set; }

        public string Status { get; set; }

    }
}
