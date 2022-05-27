using MembernovaChallenge.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MembernovaChallenge.Contracts.Services
{
    public interface ICountriesService
    {
        Task<IReadOnlyList<Region>> GetRegions();

        Task<Region> GetRegionById(int regionId);

        Task<IReadOnlyList<Country>> GetCountries(int regionId);

        Task<bool> CheckCountry(string countryName);
    }
}