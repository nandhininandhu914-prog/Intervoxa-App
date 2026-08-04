using Intervoxa_application.Data;
using Intervoxa_application.Model;
using Microsoft.EntityFrameworkCore;

namespace Intervoxa_application.Service
{
    public class Scheduleservice :IScheduleService
    {
        private readonly AppDbContext db;

        public Scheduleservice(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<List<Schedulelistdto>> Getall()
        {
            return await db.Schedules
                .Include(x => x.Candidate)//fk name include()-load data b/w 2 tables
                .Include(x => x.Interviewer)//fk name
                .Select(x => new Schedulelistdto
                {
                    ScheduleId = x.ScheduleId,
                    InterviewTitle = x.InterviewTitle,
                    CandidateName = x.Candidate.CandidateName,
                    InterviewerName=x.Interviewer.InterviewerName,
                    Round = x.Round,
                    InterviewDate = x.InterviewDate,
                    Status = x.Status
                })
                .ToListAsync();
        }

        public async Task<ScheduleModel> AddSchedule(Scheduledto dto)
        {
            var schedule = new ScheduleModel
            {
                InterviewTitle = dto.InterviewTitle,
                CandidateId = dto.CandidateId,
                InterviewId = dto.InterviewId,
                Round = dto.Round,
                InterviewDate = dto.InterviewDate,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                MeetingType = dto.MeetingType,
                MeetingLink = dto.MeetingLink,
                Status = dto.Status
            };

            await db.Schedules.AddAsync(schedule);

            await db.SaveChangesAsync();

            return schedule;
        }

        public async Task<ScheduleModel> GetById(int id)
        {
            return await db.Schedules.FirstOrDefaultAsync(x =>x.ScheduleId==id);
        }

        public async Task<ScheduleModel> UpdateSchedule(int id, Scheduledto dto)
        {
            var schedule = await db.Schedules.FirstOrDefaultAsync(x => x.ScheduleId == id);

            if (schedule == null)
            {
                return null;
            }

            schedule.InterviewTitle = dto.InterviewTitle;
            schedule.CandidateId = dto.CandidateId;
            schedule.InterviewId = dto.InterviewId;
            schedule.Round = dto.Round;
            schedule.InterviewDate = dto.InterviewDate;
            schedule.StartTime = dto.StartTime;
            schedule.EndTime = dto.EndTime;
            schedule.MeetingType = dto.MeetingType;
            schedule.MeetingLink = dto.MeetingLink;
            schedule.Status = dto.Status;

            await db.SaveChangesAsync();

            return schedule;
        }

        public async Task<ScheduleModel?> UpdateStatus(int scheduleId, string status)
        {
            var schedule = await db.Schedules
                .FirstOrDefaultAsync(x => x.ScheduleId == scheduleId);

            if (schedule == null)
            {
                return null;
            }

            schedule.Status = status;

            await db.SaveChangesAsync();

            return schedule;
        }

        public async Task<bool> DeleteSchedule(int id)
        {
            var schedule = await db.Schedules
                .FirstOrDefaultAsync(
                    x => x.ScheduleId== id);

            if (schedule == null)
            {
                return false;
            }

            db.Schedules.Remove(schedule);

            await db.SaveChangesAsync();

            return true;
        }

    }
}
