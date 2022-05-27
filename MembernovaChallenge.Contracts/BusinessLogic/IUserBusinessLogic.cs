using MembernovaChallenge.Domain.Models;
using System.Threading.Tasks;

namespace MembernovaChallenge.Contracts.BusinessLogic
{
    public interface IUserBusinessLogic
    {
        Task<User> CreateUser(CreateUserModel model);
    }
}
