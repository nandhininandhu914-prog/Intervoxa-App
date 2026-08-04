using Intervoxa_application.Model;

namespace Intervoxa_application.Service
{
    public interface ICandidateService
    {
        Task<List<CandidateModel>> Getcandidate();

        Task<CandidateModel> Addcandidate(CandidateDto candidate);//binding the req data into db obj

        Task<CandidateModel> Getbyid(int id);

        Task<CandidateModel> Editcandidate(int id,CandidateDto candidate);

        Task<bool> Deletecandidate(int id);
    }
}
