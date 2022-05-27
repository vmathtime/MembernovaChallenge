using AutoMapper;
using MembernovaChallenge.Contracts.BusinessLogic;
using MembernovaChallenge.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MembernovaChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionController : ControllerBase
    {
        [HttpGet]
        public async Task<IReadOnlyList<RegionResponse>> Get([FromServices] IRegionBusinessLogic regionBusinessLogic, [FromServices] IMapper mapper)
        {
            var regions = await regionBusinessLogic.GetRegions();
            return mapper.Map<IReadOnlyList<RegionResponse>>(regions);
        }
    }
}