using EstateManager.Dto;

namespace Authentication.Contract
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(UserDTO user);
    }
}
