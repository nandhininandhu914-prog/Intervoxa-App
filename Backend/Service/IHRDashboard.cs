using Intervoxa_application.Model;

namespace Intervoxa_application.Service
{
    public interface IHRDashboard
    {
        Task<HrDashboarddto> Get();
    }
}
