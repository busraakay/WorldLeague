using MediatR;
using System;
using System.Diagnostics.Metrics;
using WorldLeague.Application.Common.Interfaces;
using WorldLeague.Application.Features.Countries.Commands.Add;
using WorldLeague.Application.Features.Groups.Commads.Add;
using WorldLeague.Domain.Common;
using WorldLeague.Domain.Entities;
using WorldLeague.Domain.Enums;

namespace WorldLeague.Application.Features.Draws.Commands.Add
{
    public class DrawAddCommandHandler : IRequestHandler<DrawAddCommand, Response<Guid>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DrawAddCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Response<Guid>> Handle(DrawAddCommand request, CancellationToken cancellationToken)
        {
            

            if (request.NumberOfGroups == 4 && request.NumberOfGroups == 8)
            {
                var drawId = Guid.NewGuid();
                Draw draw = new Draw();
                draw.Id = drawId;
                draw.ParticipantName = request.ParticipantName;

                await _applicationDbContext.Draws.AddAsync(draw, cancellationToken);

                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                //var countryList = _applicationDbContext.Countries.ToList();
                var teamList = _applicationDbContext.Teams.ToList();

                

                if (request.NumberOfGroups == 4)
                {
                    int counter = 0;
                    
                    while (counter < 8)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            Group group = new Group();
                            group.Id = Guid.NewGuid();

                            var groupTeams = _applicationDbContext.Groups.Where(x=>x.DrawId == drawId && x.Name == (GroupName)i).ToList();

                            
                            Random random = new Random();

                            bool okey = false;
                            Team randomTeam = teamList[random.Next(0, teamList.Count)];
                            while (!okey)
                            {
                                
                                bool hasSameCountry = false;

                                foreach (var g in groupTeams)
                                {
                                    var team = _applicationDbContext.Teams.FirstOrDefault(x => x.Id == g.TeamId);
                                    if (team.CountryId == randomTeam.Id)
                                    {
                                        hasSameCountry = true;
                                        randomTeam = teamList[random.Next(0, teamList.Count)];
                                    }
                                }

                                if (!hasSameCountry)
                                {
                                    okey = true;
                                    break;
                                }
                            }

                            group.TeamId = randomTeam.Id;
                            group.DrawId = drawId;
                            await _applicationDbContext.Groups.AddAsync(group, cancellationToken);
                            await _applicationDbContext.SaveChangesAsync(cancellationToken);

                        }
                        counter++;
                    }

                }
                if(request.NumberOfGroups == 8)
                {
                    int counter = 0;

                    while (counter < 4)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            Group group = new Group();
                            group.Id = Guid.NewGuid();

                            var groupTeams = _applicationDbContext.Groups.Where(x => x.DrawId == drawId && x.Name == (GroupName)i).ToList();

                            bool hasSameCountry = true;
                            Random random = new Random();

                            Team randomTeam = teamList[random.Next(0, teamList.Count)];
                            while (hasSameCountry)
                            {

                                hasSameCountry = false;

                                foreach (var g in groupTeams)
                                {
                                    var team = _applicationDbContext.Teams.FirstOrDefault(x => x.Id == g.TeamId);
                                    if (team.CountryId == randomTeam.Id)
                                    {
                                        hasSameCountry = true;
                                        break;
                                    }
                                }
                            }

                            group.TeamId = randomTeam.Id;
                            group.DrawId = drawId;
                            await _applicationDbContext.Groups.AddAsync(group, cancellationToken);
                            await _applicationDbContext.SaveChangesAsync(cancellationToken);

                        }
                        counter++;
                    }
                }


                return new Response<Guid>($"Draw was added.");

            }
            else
            {
                return new Response<Guid>($"Please enter the number 4 or 8.");
            }
        }

    }
}
