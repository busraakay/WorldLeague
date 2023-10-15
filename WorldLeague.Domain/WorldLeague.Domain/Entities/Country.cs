using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldLeague.Domain.Common;

namespace WorldLeague.Domain.Entities
{
    public class Country : EntityBase<Guid>
    {
        public string Name { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}
