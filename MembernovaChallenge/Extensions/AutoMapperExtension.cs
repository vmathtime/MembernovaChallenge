using AutoMapper;
using MembernovaChallenge.AutoMapper.Profiles;
using MembernovaChallenge.CountriesApi.AutoMapper.Profiles;

namespace MembernovaChallenge.Extensions
{
    public static class AutoMapperExtension
    {
        public static void AddProfiles(this IMapperConfigurationExpression config)
        {
            config.AddProfile<RegionProfile>();
            config.AddProfile<CountryProfile>();
            config.AddProfile<UserProfile>();

            config.AddProfile<CountryDtoProfile>();
        }
    }
}
