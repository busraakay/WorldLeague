using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldLeague.Domain.Common;

namespace WorldLeague.Application.Features.Teams.Commands.Add
{
    public class TeamAddCommand : IRequest<Response<Guid>>
    {
        public string Name { get; set; }
        public string CountryName { get; set; }
    }
}
