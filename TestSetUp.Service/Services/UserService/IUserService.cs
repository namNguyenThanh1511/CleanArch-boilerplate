using TestSetup.Application.Services.UserService.DTOs;
using TestSetup.Domain.Entities;

namespace TestSetup.Application.Services.UserService
{
    public interface IUserService
    {
        Task<User> FindUserByEmailAsync(string email);
        Task<User> FindUserByUsernameAsync(string username);
        Task SaveUserAsync(User user);
        Task<User> FindUserByPhonenumberAsync(string phonenumber);
        Task<User> FindUserByIdAsync(string id);
        Task UpdateUserAsync(User user);
        Task<UserProfileResponse?> GetUserProfileAsync(Guid userId);
        Task<bool> UpdateUserProfileAsync(Guid userId, UserProfileUpdateDto request);

    }
}
