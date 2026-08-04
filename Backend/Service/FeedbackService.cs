using Intervoxa_application.Data;
using Intervoxa_application.Model;
using Microsoft.EntityFrameworkCore;

namespace Intervoxa_application.Service
{
    public class FeedbackService : IFeedbackService
    {
        private readonly AppDbContext db;

        public FeedbackService(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<Feedbackdto> AddFeedback(Feedbackdto dto)
        {
            // Check whether the schedule exists
            var schedule = await db.Schedules
                .FirstOrDefaultAsync(x => x.ScheduleId == dto.ScheduleId);

            if (schedule == null)
            {
                return null;
            }

            // Check whether feedback already exists
            var feedbackExists = await db.Feedbacks
                .FirstOrDefaultAsync(x => x.ScheduleId == dto.ScheduleId);

            if (feedbackExists != null)
            {
                return null;
            }

            var feedback = new FeedbackModel
            {
                ScheduleId = dto.ScheduleId,
                TechRate = dto.TechRate,
                Communication = dto.Communication,
                Comments = dto.Comments
            };

            await db.Feedbacks.AddAsync(feedback);

            await db.SaveChangesAsync();

            return dto;
        }

       /* public async Task<List<Feedbackdto>> GetAllFeedback()
        {
            return await db.Feedbacks
                .Select(x => new Feedbackdto
                {
                    ScheduleId = x.ScheduleId,
                    TechRate = x.TechRate,
                    Communication = x.Communication,
                    Comments = x.Comments
                })
                .ToListAsync();
        }*/

        public async Task<Feedbackdto?> GetFeedbackByScheduleId(int scheduleId)
        {
            var feedback = await db.Feedbacks
                .FirstOrDefaultAsync(x => x.ScheduleId == scheduleId);

            if (feedback == null)
            {
                return null;
            }

            return new Feedbackdto
            {
                ScheduleId = feedback.ScheduleId,
                TechRate = feedback.TechRate,
                Communication = feedback.Communication,
                Comments = feedback.Comments
            };
        }

        public async Task<bool> DeleteFeedback(int feedId)
        {
            var feedback = await db.Feedbacks
                .FirstOrDefaultAsync(x => x.FeedId == feedId);

            if (feedback == null)
            {
                return false;
            }

            db.Feedbacks.Remove(feedback);

            await db.SaveChangesAsync();

            return true;
        }

        public async Task<List<FeedbackViewDto>> GetAllFeedback()
        {
            return await db.Feedbacks
                .Include(f => f.ScheduleInterview)//feeback to schedule model
                    .ThenInclude(s => s.Candidate)//schedule->Candidate
                .Include(f => f.ScheduleInterview)//feeback to schedule model
                    .ThenInclude(s => s.Interviewer)//schedule->interviewer
                .Select(f => new FeedbackViewDto
                {
                    FeedId = f.FeedId,
                    CandidateName = f.ScheduleInterview.Candidate.CandidateName,
                    InterviewerName = f.ScheduleInterview.Interviewer.InterviewerName,
                    InterviewTitle = f.ScheduleInterview.InterviewTitle,
                    Round = f.ScheduleInterview.Round,
                    InterviewDate = f.ScheduleInterview.InterviewDate,
                    TechRate = f.TechRate,
                    Communication = f.Communication,
                    Comments = f.Comments,
                    FeedbackDate = f.FeedbackDate,
                    Status = f.ScheduleInterview.Status
                })
                .ToListAsync();
        }

        public async Task<List<FeedbackViewDto>> GetMyFeedback(int userId)
        {
            return await db.Feedbacks
                .Include(f => f.ScheduleInterview)
                    .ThenInclude(s => s.Candidate)
                .Include(f => f.ScheduleInterview)
                    .ThenInclude(s => s.Interviewer)
                .Where(f => f.ScheduleInterview.Interviewer.UserId == userId)
                .Select(f => new FeedbackViewDto
                {
                    FeedId = f.FeedId,
                    CandidateName = f.ScheduleInterview.Candidate.CandidateName,
                    InterviewerName = f.ScheduleInterview.Interviewer.InterviewerName,
                    InterviewTitle = f.ScheduleInterview.InterviewTitle,
                    Round = f.ScheduleInterview.Round,
                    InterviewDate = f.ScheduleInterview.InterviewDate,
                    TechRate = f.TechRate,
                    Communication = f.Communication,
                    Comments = f.Comments,
                    FeedbackDate = f.FeedbackDate,
                    Status = f.ScheduleInterview.Status
                })
                .ToListAsync();
        }
    }
}