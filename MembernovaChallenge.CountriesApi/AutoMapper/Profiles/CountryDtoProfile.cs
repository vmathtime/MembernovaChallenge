using AutoMapper;
using MembernovaChallenge.CountriesApi.Models;
using MembernovaChallenge.Domain.Models;

namespace MembernovaChallenge.CountriesApi.AutoMapper.Profiles
{
    public class CountryDtoProfile : Profile
    {
        public CountryDtoProfile()
        {
            CreateMap<CountryDto, Country>()
                .ForCtorParam(nameof(Country.Name), opt => opt.MapFrom(src => src.Name.Official));
        }
    }
}
