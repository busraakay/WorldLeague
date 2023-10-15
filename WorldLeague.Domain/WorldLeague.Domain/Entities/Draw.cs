using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldLeague.Domain.Common;

namespace WorldLeague.Domain.Entities
{
    public class Draw : EntityBase<Guid>
    {
        public string ParticipantName { get; set; }

        public int NumberOfGroups { get; set; }

        public ICollection<Group> Groups { get; set; }
    }
}
