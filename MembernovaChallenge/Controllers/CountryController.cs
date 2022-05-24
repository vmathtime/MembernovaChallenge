using MembernovaChallenge.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MembernovaChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountriesService _countriesService;

        public CountryController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string region)
        {
            var countries = await _countriesService.GetCountries(region);
            return Ok(countries);
        }
    }
}
