using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeselDataGenerator
{
    public class PeselData
    {
        private int[] _pesel;
        private readonly Century[] _centuries;
        private readonly IPeselDataControlSum _sumCalculator;
        private readonly IPeselDataValidator _validator;

        public PeselData(IPeselDataControlSum sumCalculator, IPeselDataValidator validator)
        {
            _pesel = Enumerable.Repeat(-1, 11).ToArray();
            _centuries = new Century[3];
            _sumCalculator = sumCalculator;
            _validator = validator;
        }

        public Result Run(DateTime birthDate, GenderEnum sex)
        {
            var result = new Result();

            var validation = _validator.ValidateInput(birthDate);
            if (!validation.IsValid)
            {
                result.Pesel = "";
                result.Validation = validation;
                return result;
            }
                
            ApplyCenturies();
            ApplyYear(birthDate);
            ApplyMonth(birthDate);
            ApplyDay(birthDate);
            ApplyGender(sex);
            _sumCalculator.CalculateControlSum(_pesel);

            return new Result { Pesel = string.Join("", _pesel) };
        }

        protected virtual void ApplyCenturies()
        {
            _centuries[0] = new Century(1800, 81);
            _centuries[1] = new Century(1900, 1);
            _centuries[2] = new Century(2000, 21);
        }

        protected virtual void ApplyYear(DateTime date)
        {
            var year = date.Year.ToString();
            _pesel[0] = int.Parse(year[2].ToString());
            _pesel[1] = int.Parse(year[3].ToString());
        }

        protected virtual void ApplyMonth(DateTime date)
        {
            var century = _centuries.First(c => c.Range.Contains(date.Year));
            int month = century.Months[date.Month - 1];
            if (month.ToString().Length == 1)
            {
                _pesel[2] = 0;
                _pesel[3] = month;
            }
            else
            {
                string sMonth = month.ToString();
                _pesel[2] = int.Parse(sMonth[0].ToString());
                _pesel[3] = int.Parse(sMonth[1].ToString());
            }

        }

        protected virtual void ApplyDay(DateTime date)
        {
            int day = date.Day;
            if (day.ToString().Length == 1)
            {
                _pesel[4] = 0;
                _pesel[5] = day;
            }
            else
            {
                string sDay = day.ToString();
                _pesel[4] = int.Parse(sDay[0].ToString());
                _pesel[5] = int.Parse(sDay[1].ToString());
            }
        }

        protected virtual void ApplyGender(GenderEnum sex)
        {
            var rand = new Random();
            _pesel[6] = rand.Next(0, 9);
            _pesel[7] = rand.Next(0, 9);
            _pesel[8] = rand.Next(0, 9);

            if (sex == GenderEnum.Female)
            {
                var temp = new int[] { 0, 2, 4, 6, 8 };
                _pesel[9] = temp[rand.Next(0, temp.Length - 1)];
            }
            else
            {
                var temp = new int[] { 1, 3, 5, 7, 9 };
                _pesel[9] = temp[rand.Next(0, temp.Length - 1)];
            }
        }

        protected virtual int[] ToPeselArray(string pesel) => pesel.Select(ch => int.Parse(ch.ToString())).ToArray();

        protected virtual string FromPeselArray(int[] pesel) => string.Join("", pesel);

    }
}
