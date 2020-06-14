using PeselDataGenerator;
using System;
using System.IO;

namespace DataBucket
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("START");

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "pesels.txt");

            var validator = new PeselDataValidator();
            var calculator = new PeselDataControlSum();

            var gen = new PeselData(calculator, validator);
            var result = gen.Run(new DateTime(1977, 6, 4), GenderEnum.Male);
            Console.WriteLine($"PESEL: {result.Pesel}");

            var validation = validator.Validate("77060407272", calculator);
            Console.WriteLine($"Valid: {validation.IsValid}");

            Console.WriteLine("END");
            Console.Read();
        }
    }
}
