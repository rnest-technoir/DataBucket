using System;

namespace PeselDataGenerator
{
    public interface IPeselDataValidator
    {
        ValidationResult ValidateInput(DateTime date);
        ValidationResult Validate(string rawPesel);
    }
}