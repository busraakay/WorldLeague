using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using WorldLeague.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WorldLeague.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Draw> Draws { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Team> Teams { get; set; }
        //Rollback Transation gibi herhalde
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        //int dönmesinin sebebi etkilenen kayıt sayısını döner.
        int SaveChanges();
    }
}
