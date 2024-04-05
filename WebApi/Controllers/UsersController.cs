using Application.Features.Users.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserCommand command)
    {
        var response = await Mediator.Send(command);

        return Created("", response);
    }
}
