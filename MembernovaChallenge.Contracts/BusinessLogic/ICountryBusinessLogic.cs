using MembernovaChallenge.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MembernovaChallenge.Contracts.BusinessLogic
{
    public interface ICountryBusinessLogic
    {
        Task<IReadOnlyList<Country>> GetCountries(int regionId);
    }
}
