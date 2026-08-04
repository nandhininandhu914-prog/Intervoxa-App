using Intervoxa_application.Model;

namespace Intervoxa_application.Service
{
    public interface IDashboardService
    {
        Task<DashboardDto> GetallCount();
    }
}
