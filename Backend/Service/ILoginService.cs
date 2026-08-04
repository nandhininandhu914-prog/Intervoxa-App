using Intervoxa_application.Model;

namespace Intervoxa_application.Service
{
    public interface ILoginService
    {
        Task<LoginResponseDto> Login(LoginDto loginDto);
    }
}
