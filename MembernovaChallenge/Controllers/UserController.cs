using AutoMapper;
using MembernovaChallenge.Models.Requests;
using MembernovaChallenge.Models.Responses;
using MembernovaChallenge.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MembernovaChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICountriesService _countriesService;

        public UserController(IMapper mapper, ICountriesService countriesService)
        {
            _mapper = mapper;
            _countriesService = countriesService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRequest request)
        {
            var isCorrect = await _countriesService.CheckCountry(request.Country);
            if(!isCorrect)
            {
                return BadRequest("Incorrect country name");
            }

            var response = _mapper.Map<UserResponse>(request);
            return Ok(response);
        }
    }
}
