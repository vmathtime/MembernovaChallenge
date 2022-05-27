using MembernovaChallenge.Contracts.BusinessLogic;
using MembernovaChallenge.Contracts.Services;
using MembernovaChallenge.Domain.Exceptions;
using MembernovaChallenge.Domain.Models;

namespace MembernovaChallenge.Application.BusinessLogic
{
    public class UserBusinessLogic : IUserBusinessLogic
    {
        private readonly ICountriesService _countriesService;
        private readonly IUserService _userService;

        public UserBusinessLogic(ICountriesService countriesService, IUserService userService)
        {
            _countriesService = countriesService;
            _userService = userService;
        }

        public async Task<User> CreateUser(CreateUserModel model)
        {
            var isCorrect = await _countriesService.CheckCountry(model.Country);
            if (!isCorrect)
            {
                throw new IncorrectCountryException(model.Country);
            }

            var user = await _userService.Create(model);
            return user;
        }
    }
}
