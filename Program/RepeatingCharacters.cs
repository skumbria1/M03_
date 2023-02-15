using System;
using System.Text;
using System.Collections.Generic;

namespace Program
{
    public static class RepeatingCharacters
    {
        private static bool IsSpace(char input)
        {
            return input.Equals(' ');
        }
        public static bool TryDoubleTheCharacters(string first, string second, out string result)
        {
            result = "";
            if (first is null)
            {
                return false;
            }
            if (second is null)
            {
                return false;
            }
            var alphabet = new HashSet<char>(second);
            alphabet.RemoveWhere(IsSpace);
            var temp = new StringBuilder();
            for (int i = 0; i < first.Length; i++) 
            {
                temp.Append(first[i]);
                if (alphabet.Contains(first[i]))
                {
                    temp.Append(first[i]);
                }
            }
            result = temp.ToString();
            return true;
        }
    }
}
