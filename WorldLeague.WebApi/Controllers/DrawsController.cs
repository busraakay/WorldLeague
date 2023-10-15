using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorldLeague.Application.Features.Draws.Commands.Add;
using WorldLeague.Application.Features.Teams.Commands.Add;

namespace WorldLeague.WebApi.Controllers
{
    public class DrawsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync(DrawAddCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
