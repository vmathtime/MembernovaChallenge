using AutoMapper;
using MembernovaChallenge.AutoMapper.Profiles;

namespace MembernovaChallenge.AutoMapper
{
    public static class AutoMapperExtension
    {
        public static void AddProfiles(this IMapperConfigurationExpression config)
        {
            config.AddProfile<UserRequestProfile>();
        }
    }
}
