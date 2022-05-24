using AutoMapper;
using MembernovaChallenge.Models.Requests;
using MembernovaChallenge.Models.Responses;

namespace MembernovaChallenge.AutoMapper.Profiles
{
    public class UserRequestProfile : Profile
    {
        public UserRequestProfile()
        {
            CreateMap<UserRequest, UserResponse>();
        }
    }
}
