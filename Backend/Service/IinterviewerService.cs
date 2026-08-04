using Intervoxa_application.Model;

namespace Intervoxa_application.Service
{
    public interface IinterviewerService
    {
        Task<InterviewModel> Add(InterviewerDto dto);
        Task<List<InterviewModel>> Getall();
        Task<InterviewModel> GetByID(int id);
        Task<InterviewModel> Update(int id,InterviewerDto dto);
        Task<bool> Delete(int id);
    }
}
