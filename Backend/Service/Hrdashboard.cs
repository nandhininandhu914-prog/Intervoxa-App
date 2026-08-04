using Intervoxa_application.Data;
using Intervoxa_application.Model;
using Microsoft.EntityFrameworkCore;

namespace Intervoxa_application.Service
{
    public class Hrdashboard : IHRDashboard
    {
        private readonly AppDbContext db;
        public Hrdashboard(AppDbContext db) 
        {
            this.db = db;
        }

        public async Task<HrDashboarddto> Get()
        {
            var today=DateTime.Today;
            return new HrDashboarddto
            {
                TodayInterviews = await db.Schedules.CountAsync(x => x.InterviewDate == today),
                TotalInterviews = await db.Schedules.CountAsync(),
                ScheduledInterviews = await db.Schedules.CountAsync(x => x.Status == "Scheduled"),
                CompletedInterviews = await db.Schedules.CountAsync(x => x.Status == "Completed")
            };   
        }


    }
}
