using AutoMapper;
using MembernovaChallenge.Contracts.BusinessLogic;
using MembernovaChallenge.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MembernovaChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly IMapper _mapper;

        public CountryController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IReadOnlyList<CountryResponse>> Get([FromServices] ICountryBusinessLogic countryBusinessLogic, [FromQuery] int regionId)
        {
            var countries = await countryBusinessLogic.GetCountries(regionId);
            return _mapper.Map<IReadOnlyList<CountryResponse>>(countries);
        }
    }
}