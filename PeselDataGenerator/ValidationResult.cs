using System;
using System.Collections.Generic;
using System.Text;

namespace PeselDataGenerator
{
    public class ValidationResult
    {
        public IList<string> Massages { get; private set; }
        public bool IsValid { get; set; }

        public ValidationResult()
        {
            Massages = new List<string>();
        }

        
    }
}
