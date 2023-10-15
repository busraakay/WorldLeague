using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldLeague.Domain.Common;

namespace WorldLeague.Application.Features.Draws.Commands.Add
{
    public class DrawAddCommand : IRequest<Response<Guid>>
    {
        public string ParticipantName { get; set; }

        public int NumberOfGroups { get; set; }
    }
}
