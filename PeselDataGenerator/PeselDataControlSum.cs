using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeselDataGenerator
{
    public class PeselDataControlSum : IPeselDataControlSum
    {
        private readonly int[] _controls;

        public PeselDataControlSum()
        {
            _controls = new int[10] { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
        }
        public void CalculateControlSum(int[] pesel)
        {
            int[] values = new int[10];

            for (int i = 0; i < _controls.Length; i++)
            {
                int result = pesel[i] * _controls[i];
                if (result.ToString().Length > 1)
                    values[i] = int.Parse(result.ToString()[1].ToString());
                else
                    values[i] = result;
            }
            int sum = values.Sum();
            if (sum.ToString().Length > 1)
            {
                sum = int.Parse(sum.ToString()[1].ToString());
            }
            pesel[10] = 10 - sum;
        }
    }
}
