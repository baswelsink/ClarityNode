using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClarityNode.Models
{
    internal class ExchangeRate
    {
        public long Id { get; set; }

        public int BaseCurrencyId { get; set; }

        public Currency BaseCurrency { get; set; } = null!;

        public int CounterCurrencyId { get; set; }

        public Currency CounterCurrency { get; set; } = null!;

        public double Value { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        
    }
}
