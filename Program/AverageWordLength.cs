using System;
using System.Text;

namespace Program
{
    public static class AverageWordLength
    {
        private static bool IsLastLetter(string input, int index)
        {
            if (char.IsLetter(input[index]) && !char.IsLetter(input[index + 1]))
            {
                return true;
            }
            return false;
        }
        public static bool TryCalculate(string input, out double result)
        {
            if (input is null)
            {
                result = 0.0;
                return false;
            }
            var temp = new StringBuilder(input + '.');
            var wordCount = 0.0;
            var letterCount = 0.0;
            for (int i = 0; i < temp.Length; i++)
            {
                if (char.IsLetter(temp[i])) 
                { 
                    letterCount++; 
                }
                if (i < temp.Length - 1 && IsLastLetter(temp.ToString(), i))
                {
                    wordCount++;
                }
            }
            if (letterCount == 0.0)
            {
                result = 0.0;
                return true;
            }
            result = letterCount / wordCount;
            return true;
        }
    }
}
