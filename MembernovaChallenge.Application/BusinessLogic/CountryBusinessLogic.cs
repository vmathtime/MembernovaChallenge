using MembernovaChallenge.Contracts.BusinessLogic;
using MembernovaChallenge.Contracts.Services;
using MembernovaChallenge.Domain.Models;
using Microsoft.Extensions.Logging;

namespace MembernovaChallenge.Application.BusinessLogic
{
    public class CountryBusinessLogic : ICountryBusinessLogic
    {
        private readonly ILogger _logger;
        private readonly ICountriesService _countriesService;

        public CountryBusinessLogic(ILogger<CountryBusinessLogic> logger, ICountriesService countriesService)
        {
            _logger = logger;
            _countriesService = countriesService;
        }

        public async Task<IReadOnlyList<Country>> GetCountries(int regionId)
        {
            var countries = await _countriesService.GetCountries(regionId);
            if (!countries.Any())
            {
                _logger.LogError("Countries for region with id: '{regionId}' not found", regionId);
            }

            return countries;
        }
    }
}
