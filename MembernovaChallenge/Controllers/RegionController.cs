using MembernovaChallenge.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MembernovaChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly ICountriesService _countriesService;

        public RegionController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var regions = await _countriesService.GetRegions();
            return Ok(regions);
        }
    }
}
