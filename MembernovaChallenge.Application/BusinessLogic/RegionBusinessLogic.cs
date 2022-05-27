using MembernovaChallenge.Contracts.BusinessLogic;
using MembernovaChallenge.Contracts.Services;
using MembernovaChallenge.Domain.Models;

namespace MembernovaChallenge.Application.BusinessLogic
{
    public class RegionBusinessLogic : IRegionBusinessLogic
    {
        private readonly ICountriesService _countriesService;

        public RegionBusinessLogic(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        public async Task<IReadOnlyList<Region>> GetRegions() => await _countriesService.GetRegions();
    }
}
