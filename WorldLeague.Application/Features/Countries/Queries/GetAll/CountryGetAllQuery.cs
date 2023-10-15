using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldLeague.Application.Features.Countries.Queries.GetAll
{
    public class CountryGetAllQuery : IRequest<List<CountryGetAllDto>>
    {
        public CountryGetAllQuery()
        {
        }
    }
}
