using MembernovaChallenge.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MembernovaChallenge.Contracts.BusinessLogic
{
    public interface IRegionBusinessLogic
    {
        Task<IReadOnlyList<Region>> GetRegions();
    }
}
