using MediatR;
using WorldLeague.Domain.Common;

namespace WorldLeague.Application.Features.Countries.Commands.Add
{
    public class CountryAddCommand : IRequest<Response<Guid>>
    {
        public string Name { get; set; }
    }
}
