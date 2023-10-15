using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldLeague.Application.Common.Interfaces;
using WorldLeague.Domain.Entities;

namespace WorldLeague.Application.Features.Countries.Queries.GetAll
{
    public class CountryGetAllQueryHandler : IRequestHandler<CountryGetAllQuery, List<CountryGetAllDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CountryGetAllQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<List<CountryGetAllDto>> Handle(CountryGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbQuery = _applicationDbContext.Countries.AsQueryable();

            var countries = await dbQuery.ToListAsync(cancellationToken);

            var countrytDtos = MapCountriesToGetAllDtos(countries);

            return countrytDtos.ToList();
        }

        private IEnumerable<CountryGetAllDto> MapCountriesToGetAllDtos(List<Country> countries)
        {
            foreach (var country in countries)
            {
                yield return new CountryGetAllDto()
                {
                    Name = country.Name,
                };
            }
        }
    }
}
