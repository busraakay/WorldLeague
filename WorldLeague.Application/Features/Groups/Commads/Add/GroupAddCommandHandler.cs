using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldLeague.Application.Common.Interfaces;
using WorldLeague.Application.Features.Countries.Commands.Add;
using WorldLeague.Domain.Common;
using WorldLeague.Domain.Entities;

namespace WorldLeague.Application.Features.Groups.Commads.Add
{
    public class GroupAddCommandHandler : IRequestHandler<GroupAddCommand, Response<Guid>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GroupAddCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Response<Guid>> Handle(GroupAddCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var group = new Group()
            {
                Id = id,
                Name = request.Name,
                TeamId = request.TeamId,
                DrawId = request.DrawId,
            };

            await _applicationDbContext.Groups.AddAsync(group, cancellationToken);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return new Response<Guid>($"The new country named \"{group.Name}\" was successfully added.", group.Id);
        }
    }
}
