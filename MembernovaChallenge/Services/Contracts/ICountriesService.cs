namespace MembernovaChallenge.Services.Contracts
{
    public interface ICountriesService
    {
        Task<IReadOnlyList<string>> GetRegions();

        Task<IReadOnlyList<string>> GetCountries(string region);

        Task<bool> CheckCountry(string country);
    }
}
