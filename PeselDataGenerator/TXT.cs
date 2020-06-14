using System;
using System.Collections.Generic;
using System.Text;

namespace PeselDataGenerator
{
    internal class TXT
    {
        public static string InvalidInputValue { get => "Invalid input value"; }
        public static string InvalidOutputValue { get => "Invalid output value"; }
        public static string YearOutOfRange { get => "Year out of range"; }
        public static string InvalidYearLength { get => "Invalid year length"; }
        public static string AllPeselSignsMustBeNumbers { get => "All PESEL signs must be a numbers"; }
        public static string AllPeselSignsMustBePositiveNumbers { get => "All PESEL signs must be a positive numbers"; }
        public static string InvalidPeselLenght { get => "Invalid PESEL length"; }
        public static string ValidationFailed { get => "PESEL number validation failed. Wrong control sum"; }
    }
}
