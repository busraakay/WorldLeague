using Microsoft.AspNetCore.Mvc;
using WorldLeague.Application.Features.Countries.Commands.Add;
using WorldLeague.Application.Features.Countries.Queries.GetAll;

namespace WorldLeague.WebApi.Controllers
{
    public class CountriesController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync(CountryAddCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllAsync(CountryGetAllQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
