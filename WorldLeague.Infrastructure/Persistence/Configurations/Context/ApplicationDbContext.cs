using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WorldLeague.Application.Common.Interfaces;
using WorldLeague.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WorldLeague.Infrastructure.Persistence.Configurations.Context
{
    public class ApplicationDbContext: DbContext, IApplicationDbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Draw> Draws { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Team> Teams { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configurations
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Ignores
           
            base.OnModelCreating(modelBuilder);
        }
    }
}
