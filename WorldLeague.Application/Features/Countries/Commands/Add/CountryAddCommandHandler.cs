using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldLeague.Application.Common.Interfaces;
using WorldLeague.Domain.Common;
using WorldLeague.Domain.Entities;

namespace WorldLeague.Application.Features.Countries.Commands.Add
{
    public class CountryAddCommandHandler : IRequestHandler<CountryAddCommand, Response<Guid>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CountryAddCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Response<Guid>> Handle(CountryAddCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var country = new Country()
            {
                Id = id,
                Name = request.Name
            };

            await _applicationDbContext.Countries.AddAsync(country, cancellationToken);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return new Response<Guid>($"The new country named \"{country.Name}\" was successfully added.", country.Id);
        }   
    }
}
