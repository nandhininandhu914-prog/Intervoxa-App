using Intervoxa_application.Data;
using Intervoxa_application.Model;
using Microsoft.EntityFrameworkCore;

namespace Intervoxa_application.Service
{
    public class DasboardService:IDashboardService
    {
        private readonly AppDbContext db;

        public DasboardService(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<DashboardDto> GetallCount()
        {
            return new DashboardDto
            {
                TotalCandidates = await db.Candidates.CountAsync(),
                TotalInterviewers = await db.Interviews.CountAsync(),
                TotalScheduledInterviews = await db.Schedules.CountAsync(x=>
                x.Status== "Scheduled"),
                CompletedInterviews = await db.Schedules.CountAsync(
                    x => x.Status == "Completed")
            };
        }
    }
}
