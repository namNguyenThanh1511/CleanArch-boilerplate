using TestSetup.Application.Services.AuthService.DTOs;
using TestSetup.Application.Services.TokenService.DTOs;

namespace TestSetup.Application.Services.AuthService
{
    public interface IAuthService
    {
        Task RegisterAsync(UserCreationDto request);

        Task<TokenResponse> LoginAsync(UserLoginDto request);

    }
}
