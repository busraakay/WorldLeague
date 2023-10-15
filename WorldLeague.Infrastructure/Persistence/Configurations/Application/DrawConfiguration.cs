using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldLeague.Domain.Entities;

namespace WorldLeague.Infrastructure.Persistence.Configurations.Application
{
    public class DrawConfiguration : IEntityTypeConfiguration<Draw>
    {
        public void Configure(EntityTypeBuilder<Draw> builder)
        {
            // Id
            builder.HasKey(x => x.Id);

            // Name
            builder.Property(x => x.ParticipantName).IsRequired(true);
            builder.Property(x => x.ParticipantName).HasMaxLength(150);

            // NumberOfGroups
            builder.Property(x => x.NumberOfGroups).IsRequired(true);
            builder.Property(x => x.NumberOfGroups).HasConversion<int>();

            //Relationships
            builder.HasMany<Group>(x => x.Groups).WithOne(x => x.Draw).HasForeignKey(x => x.DrawId);

            builder.ToTable("Draws");
        }
    }
}
