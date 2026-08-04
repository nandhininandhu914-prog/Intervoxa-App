using Intervoxa_application.Data;
using Intervoxa_application.Model;
using Microsoft.EntityFrameworkCore;

namespace Intervoxa_application.Service
{
    public class InterviewerdashboardService:IInterviewerdashboardService
    {
        private readonly AppDbContext db;

        public InterviewerdashboardService(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<Interviewerdashboarddto> Getdashboard(int InterviewerId)
        {

            var today = DateTime.Today;

            var interviews = await db.Schedules
                .Where(x => x.InterviewId == InterviewerId)
                .ToListAsync();
            return new Interviewerdashboarddto
            {
                TodayInterviews = interviews.Count(x =>
                 x.InterviewDate.Date == today),

                UpcomingInterviews = interviews.Count(x =>
                    x.InterviewDate.Date > today),

                CompletedInterviews = interviews.Count(x =>
                    x.Status == "Completed"),

                TotalAssignedInterviews = interviews.Count
            };

        }

        public async Task<List<Schedulelistdto>> GetInterviewbyId(int interviewid)
        {
        return await db.Schedules
        .Include(x => x.Candidate)
        .Include(x => x.Interviewer)
        .Where(x => x.InterviewId == interviewid)
        .OrderBy(x => x.InterviewDate)
        .Select(x => new Schedulelistdto
        {
            ScheduleId = x.ScheduleId,
            InterviewTitle = x.InterviewTitle,
            CandidateName = x.Candidate.CandidateName,
            InterviewerName = x.Interviewer.InterviewerName,
            Round = x.Round,
            InterviewDate = x.InterviewDate,
            Status = x.Status
        })
        .ToListAsync();
        }
    }
}
