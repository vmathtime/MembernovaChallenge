using AutoMapper;
using MembernovaChallenge.Domain.Models;
using MembernovaChallenge.Models.Responses;

namespace MembernovaChallenge.AutoMapper.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, RegionResponse>();
        }
    }
}
