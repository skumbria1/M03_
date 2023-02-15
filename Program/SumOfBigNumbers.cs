using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Program
{
    public static class SumOfBigNumbers
    {
        private static bool StringIsValid(string input)
        {
            var regex = new Regex(@"^0$|^[1-9]\d*$");
            if (regex.IsMatch(input))
            {
                return true;
            }
            return false;
        }

        private static string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private static void CountMatchingPart(string first, string second, 
            StringBuilder temp, out int carry)
        {
            var lengthDifference = first.Length - second.Length;
            carry = 0;
            for (int i = second.Length - 1; i >= 0; i--)
            {
                int sum = (int)char.GetNumericValue(first[i + lengthDifference]) +
                    (int)char.GetNumericValue(second[i]) + carry;
                carry = sum / 10;
                temp.Append(sum % 10);
            }
        }

        private static void CountRemaining(string first, int secondStringLength,
            StringBuilder temp, int carry)
        {
            var lengthDifference = first.Length - secondStringLength;
            for (int i = lengthDifference - 1; i >= 0; i--)
            {
                int sum = (int)char.GetNumericValue(first[i]) + carry;
                carry = sum / 10;
                temp.Append(sum % 10);
            }
            if (carry > 0)
            {
                temp.Append(carry);
            }
        }

        public static bool TryCalculate(string first, string second, out string result)
        {
            result = "";
            if (first is null || second is null || 
                !StringIsValid(first) || !StringIsValid(second))
            {
                return false;
            }
            if (second.Length > first.Length)
            {
                string t = first;
                first = second;
                second = t;
            }
            var temp = new StringBuilder();
            CountMatchingPart(first, second, temp, out int carry);
            CountRemaining(first, second.Length, temp, carry);
            result = ReverseString(temp.ToString());
            return true;
        }
    }
}
