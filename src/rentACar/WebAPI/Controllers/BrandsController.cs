using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        // GET: api/<BrandsController>
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBrandQuery getListBrandQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListBrandDto> response = await Mediator.Send(getListBrandQuery);
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdBrandQuery getByIdBrandQuery = new() { Id = id};
            GetByIdBrandResponse response = await Mediator.Send(getByIdBrandQuery);
            return Ok(response);
        }
        
        // // GET api/<BrandsController>/5
        // [HttpGet("{id}")]
        // public string Get(int id)
        // {
        //     return "value";
        // }

        // POST api/<BrandsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBrandCommand command)
        {
            
         var response = await Mediator.Send(command);

         return Ok(response);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBrandCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
        
        

        // // PUT api/<BrandsController>/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }
        //
        // // DELETE api/<BrandsController>/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
