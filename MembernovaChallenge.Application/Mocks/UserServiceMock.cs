using MembernovaChallenge.Contracts.Services;
using MembernovaChallenge.Domain.Models;

namespace MembernovaChallenge.Application.Mocks
{
    public class UserServiceMock : IUserService
    {
        private readonly ICountriesService _countriesService;

        public UserServiceMock(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        public async Task<User> Create(CreateUserModel model)
        {
            var region = await _countriesService.GetRegionById(model.RegionId);
            return new User(model.FirstName, model.LastName, model.Email, region, new Country(model.Country));
        }
    }
}
