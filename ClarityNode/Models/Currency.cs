using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClarityNode.Models
{
    internal class Currency
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }
    }
}
