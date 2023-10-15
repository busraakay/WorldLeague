using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldLeague.Domain.Common;
using WorldLeague.Domain.Enums;

namespace WorldLeague.Domain.Entities
{
    public class Group : EntityBase<Guid>
    {
        public GroupName Name { get; set; }

        public Guid TeamId { get; set; }
        public Team Team { get; set; }

        public Guid DrawId { get; set; }
        public Draw Draw { get; set; }
    }
}
