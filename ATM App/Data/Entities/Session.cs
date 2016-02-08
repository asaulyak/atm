using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Session : BaseEntity
    {
        public bool IsActive { get; set; }
        public virtual Card Card { get; set; }
        public Guid SessionId { get; set; }
        public DateTime Expires { get; set; }
    }
}
