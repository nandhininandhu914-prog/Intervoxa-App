using Intervoxa_application.Model;
using Microsoft.EntityFrameworkCore;

namespace Intervoxa_application.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options) { }


        public DbSet<UserModel> Users { get; set; }

        public DbSet<CandidateModel> Candidates { get; set; }

        public DbSet<InterviewModel> Interviews { get; set; }

        public DbSet<ScheduleModel> Schedules { get; set; }

        public DbSet<FeedbackModel> Feedbacks { get; set; }

        

    }
}
