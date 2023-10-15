using Microsoft.AspNetCore.Mvc;
using WorldLeague.Application.Features.Countries.Commands.Add;
using WorldLeague.Application.Features.Teams.Commands.Add;

namespace WorldLeague.WebApi.Controllers
{
    public class TeamsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync(TeamAddCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
