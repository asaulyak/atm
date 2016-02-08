using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Card : BaseEntity
    {
        public string CardNumber { get; set; }
        public float Balance { get; set; }
        public string PinHash { get; set; }
        public bool IsBlocked { get; set; }
        public int IncorectPins { get; set; }
    }
}
