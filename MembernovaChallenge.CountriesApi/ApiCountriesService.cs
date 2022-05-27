using AutoMapper;
using MembernovaChallenge.Contracts.Services;
using MembernovaChallenge.CountriesApi.Models;
using MembernovaChallenge.CountriesApi.Models.Enums;
using MembernovaChallenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MembernovaChallenge.CountriesApi
{
    public class ApiCountriesService : ICountriesService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public ApiCountriesService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        public Task<IReadOnlyList<Region>> GetRegions()
        {
            IReadOnlyList<Region> regions = Enum.GetValues(typeof(RegionEnumDto))
                .Cast<RegionEnumDto>()
                .Select(el => new Region((int)el, el.ToString()))
                .OrderBy(el => el.Name)
                .ToList();
            return Task.FromResult(regions);
        }

        public Task<Region> GetRegionById(int regionId)
        {
            if (!Enum.IsDefined(typeof(RegionEnumDto), regionId))
            {
                throw new ArgumentException($"Region with id: '{regionId}' not exists", nameof(regionId));
            }

            var regionDto = (RegionEnumDto)regionId;
            var region = new Region(regionId, regionDto.ToString());
            return Task.FromResult(region);
        }

        public async Task<IReadOnlyList<Country>> GetCountries(int regionId)
        {
            if(!Enum.IsDefined(typeof(RegionEnumDto), regionId))
            {
                return Array.Empty<Country>();
            }

            var regionDto = (RegionEnumDto)regionId;
            var response = await _httpClient.GetAsync($"region/{regionDto}");
            if (!response.IsSuccessStatusCode)
            {
                return Array.Empty<Country>();
            }

            var countries = await response.Content.ReadFromJsonAsync<IEnumerable<CountryDto>>();
            if (countries == null || !countries.Any())
            {
                return Array.Empty<Country>();
            }

            return _mapper.Map<IEnumerable<Country>>(countries)
                .OrderBy(el => el.Name)
                .ToList();
        }

        public async Task<bool> CheckCountry(string countryName)
        {
            var response = await _httpClient.GetAsync($"name/{countryName}?fullText=true");
            return response.IsSuccessStatusCode;
        }
    }
}