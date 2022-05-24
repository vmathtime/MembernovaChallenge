using MembernovaChallenge.Helpers;
using MembernovaChallenge.Services.Contracts;
using MembernovaChallenge.Services.Contracts.Models;

namespace MembernovaChallenge.Services
{
    public class ApiCountriesService : ICountriesService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;

        public ApiCountriesService(HttpClient httpClient, ILogger<ApiCountriesService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public Task<IReadOnlyList<string>> GetRegions()
        {
            IReadOnlyList<string> regions = Enum.GetValues(typeof(Region))
                .Cast<Region>()
                .Select(el => el.ToString())
                .OrderBy(el => el)
                .ToList();
            return Task.FromResult(regions);
        }

        public async Task<IReadOnlyList<string>> GetCountries(string region)
        {
            var response = await _httpClient.GetAsync($"region/{region}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError(content);
                return Array.Empty<string>();
            }

            var countries = JsonHelper.Deserialize<IEnumerable<CountryDto>>(content);
            if(countries == null)
            {
                return Array.Empty<string>();
            }

            return countries.Select(el => el.Name.Official)
                .OrderBy(el => el)
                .ToList();
        }

        public async Task<bool> CheckCountry(string country)
        {
            var response = await _httpClient.GetAsync($"name/{country}?fullText=true");
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                _logger.LogError(content);
                return false;
            }

            return true;
        }
    }
}
