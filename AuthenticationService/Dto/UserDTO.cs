using System.Reflection.Metadata.Ecma335;

namespace EstateManager.Dto
{
    public class UserDTO
    {
        public required Guid Identifier { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateOnly Dob { get; set; }
        public required string UserName { get; set; }
        public required string UserEmail { get; set; }
        public required string PhoneNumber { get; set; }
    }

  public  class UserRequest
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateOnly Dob { get; set; }
        public required string UserName { get; set; }
        public required string UserEmail { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }
    }


    public class UserResponse : ServiceResponse
    {
        public UserResponse(int code, string message) : base(code, message)
        {
        }

        public UserDTO user { get; set; } = null!;
    }

    public class  ServiceResponse
    {
        public ServiceResponse(int code, string message)
        {
            this.message = message;
            this.code = code;
        }
        public int code;
       public string message;
    }
     
}
