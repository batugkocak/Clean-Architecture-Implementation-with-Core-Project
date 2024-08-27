using Application.Features.Models.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
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
    }
}
