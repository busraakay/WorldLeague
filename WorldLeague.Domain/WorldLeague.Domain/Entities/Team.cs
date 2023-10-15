using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldLeague.Domain.Common;

namespace WorldLeague.Domain.Entities
{
    public class Team : EntityBase<Guid>
    {
        public string Name { get; set; }

        public Guid CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<Group> Groups { get; set; }

    }
}
