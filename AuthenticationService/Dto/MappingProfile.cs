using AutoMapper;
using EstateManager.Contract;
using EstateManager.Models;

namespace EstateManager.Dto
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
           CreateMap<UserDTO, Users>().ForMember(d => d.Email, opt => opt
              .MapFrom(src => src.UserEmail)).ReverseMap(); 
           CreateMap<UserRequest, Users>().ForMember(d => d.Email, opt => opt
              .MapFrom(src => src.UserEmail)).ReverseMap();
            //CreateMap<User, Users>().ReverseMap();
        }
    }
}
