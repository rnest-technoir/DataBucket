using System;
using System.Collections.Generic;
using System.Text;

namespace PeselDataGenerator
{
    public class Result
    {
        public string Pesel { get; set; }
        public ValidationResult Validation { get; set; }

        public Result()
        {
            Validation = new ValidationResult { IsValid = true };
        }
    }
}
