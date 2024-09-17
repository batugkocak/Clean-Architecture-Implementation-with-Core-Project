using Application.Features.Users.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UsersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
    {
            
        var response = await Mediator.Send(command);

        return Ok(response);
    }
}