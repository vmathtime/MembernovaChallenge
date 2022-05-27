using AutoMapper;
using MembernovaChallenge.Domain.Models;
using MembernovaChallenge.Models.Responses;

namespace MembernovaChallenge.AutoMapper.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryResponse>();
        }
    }
}
