using Intervoxa_application.Model;

namespace Intervoxa_application.Service
{
    public interface IScheduleService
    {
        Task<List<Schedulelistdto>> Getall();

        Task<ScheduleModel> GetById(int id);

        Task<ScheduleModel> AddSchedule(Scheduledto schedule);

        Task<ScheduleModel> UpdateSchedule(int id, Scheduledto schedule);

        Task<ScheduleModel?> UpdateStatus(int scheduleId, string status);

        Task<bool> DeleteSchedule(int id);
    }
}
