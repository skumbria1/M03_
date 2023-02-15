using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Program
{
    public static class StringWordsReverser
    {
        private static bool StringIsValid(string input)
        {
            var regex = new Regex(@"^[a-zA-Z]+( [a-zA-Z]+)*$");
            if (regex.IsMatch(input))
            {
                return true;
            }
            return false;
        }
        public static bool TryReverseWords(string input, out string result)
        {
            result = "";
            if (input is null || !StringIsValid(input))
            {
                return false;
            }
            string[] substrings = input.Split(' ');
            Array.Reverse(substrings);
            result = string.Join(' ', substrings);
            return true;
        }
    }
}
