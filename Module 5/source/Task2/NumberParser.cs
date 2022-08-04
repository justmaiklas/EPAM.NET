﻿using System;
using System.Linq;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            CheckForNull(stringValue);
            var isNegativeNumber = FormatStringAndGetIsNegative(ref stringValue);
            CheckForFormat(stringValue);
            var number = ParseNumber(stringValue, isNegativeNumber);
            return (int)number;
        }

        private static long ParseNumber(string stringValue, bool isNegativeNumber)
        {
            long number = 0;
            foreach (var c in stringValue)
            {
                number *= 10;
                var digit = c - '0';
                number += digit;
            }
            if (isNegativeNumber)
            {
                number *= -1;
            }

            CheckForOverFlow(number);
            return number;
        }

        private static bool FormatStringAndGetIsNegative(ref string stringValue)
        {
            stringValue = stringValue.Trim();
            var isNegativeNumber = false;
            if (stringValue.StartsWith("-"))
            {
                isNegativeNumber = true;
                stringValue = stringValue[1..];
            }
            else if (stringValue.StartsWith("+"))
            {
                stringValue = stringValue[1..];
            }
            return isNegativeNumber;
        }

        private static void CheckForNull(string stringValue)
        {
            if (stringValue == null) throw new ArgumentNullException(nameof(stringValue));
        }
        private static void CheckForFormat(string stringValue)
        {
            if (stringValue.Length == 0 || stringValue.Any(c => !char.IsDigit(c))) throw new FormatException();

        }
        private static void CheckForOverFlow(long number)
        {
            if (number > int.MaxValue || number < int.MinValue)
            {
                throw new OverflowException();
            }
        }
    }
}