using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldLeague.Domain.Common;
using WorldLeague.Domain.Enums;

namespace WorldLeague.Application.Features.Groups.Commads.Add
{
    public class GroupAddCommand : IRequest<Response<Guid>>
    {
        public GroupName Name { get; set; }
        public Guid TeamId { get; set; }
        public Guid DrawId { get; set; }
    }
}
