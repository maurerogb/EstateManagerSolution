using EstateManager.Dto;
using EstateManager.Models;

namespace EstateManager.Contract
{
    public interface IUsersService
    {
        Task<UserResponse> AddUser(UserRequest request);
        UserResponse GetUserByUserName(string userName);
        UserResponse UpdateUser(UserRequest request);
        UserResponse DeleteUser(UserRequest request);         

    }
}
    