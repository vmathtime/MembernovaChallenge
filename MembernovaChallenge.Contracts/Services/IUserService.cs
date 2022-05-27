using MembernovaChallenge.Domain.Models;
using System.Threading.Tasks;

namespace MembernovaChallenge.Contracts.Services
{
    public interface IUserService
    {
        Task<User> Create(CreateUserModel model);
    }
}
