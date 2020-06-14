using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeselDataGenerator
{
    public class PeselDataValidator : IPeselDataValidator
    {
        public virtual ValidationResult ValidateInput(DateTime date)
        {
            var result = new ValidationResult();
            result.IsValid = false;

            var year = date.Year;

            if (year > 2099 && year < 1800)
                result.Massages.Add(TXT.YearOutOfRange);
            if (year.ToString().Length != 4)
                result.Massages.Add(TXT.InvalidYearLength);

            if (!result.Massages.Any())
                result.IsValid = true;

            return result;
        }

        public virtual ValidationResult Validate(string rawPesel)
        {
            var result = new ValidationResult();

            if (rawPesel.Any(ch => !char.IsDigit(ch)))
                result.Massages.Add(TXT.AllPeselSignsMustBeNumbers);

            int[] pesel = rawPesel.Select(ch => int.Parse(ch.ToString())).ToArray();

            if (pesel.Any(n => n < 0))
                result.Massages.Add(TXT.AllPeselSignsMustBePositiveNumbers);
            if (pesel.Length != 11)
                result.Massages.Add(TXT.InvalidPeselLenght);

            if (!result.Massages.Any())
                result.IsValid = true;

            return result;
        }

        public virtual ValidationResult Validate(string rawPesel, IPeselDataControlSum controlSumCalculator)
        {
            var result = new ValidationResult();

            int[] pesel = rawPesel.Select(ch => int.Parse(ch.ToString())).ToArray();
            int origSum = pesel[pesel.Length - 1];
            pesel[pesel.Length - 1] = -1;

            controlSumCalculator.CalculateControlSum(pesel);

            if(origSum != pesel[pesel.Length - 1])
                result.Massages.Add(TXT.ValidationFailed);

            if (!result.Massages.Any())
                result.IsValid = true;

            return result;
        }

    }
}
