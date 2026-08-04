using Intervoxa_application.Model;

namespace Intervoxa_application.Service
{
    public interface IInterviewerdashboardService
    {
        Task<Interviewerdashboarddto> Getdashboard(int InterviewId);
        Task<List<Schedulelistdto>> GetInterviewbyId(int interviewid);
    }
}
    