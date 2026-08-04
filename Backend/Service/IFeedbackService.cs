using Intervoxa_application.Model;

namespace Intervoxa_application.Service
{
    public interface IFeedbackService
    {
        Task<Feedbackdto> AddFeedback(Feedbackdto dto);

        Task<List<FeedbackViewDto>> GetAllFeedback();

        Task<Feedbackdto?> GetFeedbackByScheduleId(int scheduleId);

        Task<bool> DeleteFeedback(int feedId);

        Task<List<FeedbackViewDto>> GetMyFeedback(int userId);
    }
}
