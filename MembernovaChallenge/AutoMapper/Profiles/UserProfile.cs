using AutoMapper;
using MembernovaChallenge.Domain.Models;
using MembernovaChallenge.Models.Requests;
using MembernovaChallenge.Models.Responses;

namespace MembernovaChallenge.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRequest, CreateUserModel>();
            CreateMap<User, UserResponse>()
                .ForCtorParam(nameof(UserResponse.Region), opt => opt.MapFrom(src => src.Region.Name))
                .ForCtorParam(nameof(UserResponse.Country), opt => opt.MapFrom(src => src.Country.Name));
        }
    }
}
