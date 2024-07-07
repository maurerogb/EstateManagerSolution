using AutoMapper;
using EstateManager.Contract;
using EstateManager.Data;
using EstateManager.Dto;
using EstateManager.Models;
using Microsoft.AspNetCore.Identity;
using System.Text;

namespace Authentication.Services
{
    public class UserService(UserManager<Users> manager, AppDbContext dbContext, IMapper mapper) : IUsersService
    {

        public async Task<UserResponse> AddUser(UserRequest request)
        {
            var response = new UserResponse(1001, "Error occured.");
            if (string.IsNullOrWhiteSpace(request.UserName))
            {
                return new UserResponse(1001, "Username is required.");
            }

            if (request.FirstName == null)
            {
                return new UserResponse(1001, "FirstName is required.");
            }
            if (request.LastName == null)
            {
                return new UserResponse(1001, "LastName is required.");
            }
            if (request.UserEmail == null)
            {
                return new UserResponse(1001, "Email is required.");
            }
            if (request.PhoneNumber == null)
            {
                return new UserResponse(1001, "PhoneNumber is required.");
            }
            if (request.Password == null)
            {
                return new UserResponse(1001, "Password is required.");
            }
            if (request.Dob.ToString() == null)
            {
                return new UserResponse(1001, "Date of Birth is required.");
            }



            var user = mapper.Map<Users>(request);

            //var checkUser = await  manager.FindByNameAsync( user.UserName);
            //if (checkUser != null) {
            //    return new UserResponse(1001, "user name already exist.");
            //}
            user.Identifier = Guid.NewGuid();
            user.CreatedOn = DateTime.UtcNow;
            user.NormalizedEmail = user?.Email?.ToUpper();
            user.NormalizedUserName = user?.UserName?.ToUpper();

            try
            {
                var result = await manager.CreateAsync(user, request.Password);
                // dbContext.Add(user);

                if(result.Succeeded)
                {
                    var checkUser = await manager.FindByNameAsync(user.UserName);
                    response.user = mapper.Map<UserDTO>(checkUser);
                    response.code = 1000;
                    response.message = "User created successfully";
                    return response;
                }
                return response; 

            }
            catch (Exception ex)
            {

                  response.message = ex.Message;
                return response;
            }
        }

        public UserResponse DeleteUser(UserRequest request)
        {
            throw new NotImplementedException();
        }

        public UserResponse GetUserByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public UserResponse UpdateUser(UserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
