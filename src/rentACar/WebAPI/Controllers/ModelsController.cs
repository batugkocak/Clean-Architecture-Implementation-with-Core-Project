using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetListByDynamic;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        // GET: api/<ModelsController>
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListModelQuery getListBrandQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListModelDto> response = await Mediator.Send(getListBrandQuery);
            return Ok(response);
        }
        // GET: api/<ModelsController>
        [HttpPost("ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery dynamicQuery)
        {
            GetListByDynamicModelQuery getListBrandByDynamicQuery = new() { PageRequest = pageRequest, DynamicQuery = dynamicQuery};
            GetListResponse<GetListByDynamicModelDto> response = await Mediator.Send(getListBrandByDynamicQuery);
            return Ok(response);
        }
    }
}
