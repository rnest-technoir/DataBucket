using System.Collections.Generic;

namespace PeselDataGenerator
{
    public interface IPeselDataControlSum
    {
        void CalculateControlSum(int[] pesel);
    }
}