using MediatR;
using WorldLeague.Application.Common.Interfaces;
using WorldLeague.Domain.Common;
using WorldLeague.Domain.Entities;

namespace WorldLeague.Application.Features.Teams.Commands.Add
{
    public class TeamAddCommandHandler : IRequestHandler<TeamAddCommand, Response<Guid>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public TeamAddCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Response<Guid>> Handle(TeamAddCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var countryId = _applicationDbContext
                .Countries
                .Where(country => country.Name == request.CountryName).First().Id;

            var team = new Team()
            {
                Id = id,
                Name = request.Name,
                CountryId = countryId
            };

            await _applicationDbContext.Teams.AddAsync(team, cancellationToken);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new Response<Guid>($"The new team named \"{team.Name}\" was successfully added.", team.Id);
        }
    }
}
