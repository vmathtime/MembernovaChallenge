using AutoMapper;
using MembernovaChallenge.Contracts.BusinessLogic;
using MembernovaChallenge.Domain.Models;
using MembernovaChallenge.Models.Requests;
using MembernovaChallenge.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MembernovaChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserBusinessLogic _userBusinessLogic;

        public UserController(IMapper mapper, IUserBusinessLogic userBusinessLogic)
        {
            _mapper = mapper;
            _userBusinessLogic = userBusinessLogic;
        }

        [HttpPost]
        public async Task<ActionResult<UserResponse>> Create([FromBody] UserRequest request)
        {
            var model = _mapper.Map<CreateUserModel>(request);
            var user = await _userBusinessLogic.CreateUser(model);
            var response = _mapper.Map<UserResponse>(user);
            return response;
        }
    }
}