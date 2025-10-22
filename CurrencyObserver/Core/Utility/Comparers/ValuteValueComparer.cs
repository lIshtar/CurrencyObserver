using CurrencyObserver.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyObserver.Core.Utility.Comparers
{
    internal class ValuteValueComparer : IComparer<CurrencyRateRecord>
    {
        public int Compare(CurrencyRateRecord? x, CurrencyRateRecord? y)
        {
            if (x == null || y == null) return 0;

            return x.VunitRate.CompareTo(y.VunitRate);
        }
    }
}
