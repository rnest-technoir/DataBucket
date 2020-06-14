using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeselDataGenerator
{
    internal class Century
    {
        public Century(int startYear, int startMonth)
        {
            Range = Enumerable.Range(startYear, 100).ToArray();
            Months = Enumerable.Range(startMonth, 12).ToArray();
        }
        public int[] Range { get; private set; }
        public int[] Months { get; private set; }
    }
}
