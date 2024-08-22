using Application.Features.Brands.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        // // GET: api/<BrandsController>
        // [HttpGet]
        // public IEnumerable<string> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }
        //
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

         return Ok("Helo!!!");
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
