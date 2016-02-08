using Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Operation : BaseEntity
    {
        public DateTime Date { get; set; }
        public OperationType Type { get; set; }
        public virtual Session Session { get; set; }
        public float BalanceBefore { get; set; }
    }
}
