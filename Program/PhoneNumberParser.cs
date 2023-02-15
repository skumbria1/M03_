using System;
using System.IO;
using System.Text.RegularExpressions;
using Maybe;

namespace Program
{
    public interface IIO<T>
    {
        public Maybe<T> Read(string inputFilePath);
        public Maybe<T> Write(string inputFilePath, string[] input);
    }
    public class FileIO : IIO<string>
    {
        public Maybe<string> Read(string inputFilePath)
        {
            try
            {
                if (File.Exists(inputFilePath))
                {
                    string text = File.ReadAllText(inputFilePath);
                    return Maybe<string>.CreateSuccess(text);
                }
                return Maybe<string>.CreateFailure();
            }
            catch 
            {
                return Maybe<string>.CreateFailure();
            }
        }

        public Maybe<string> Write(string outputFilePath, string[] input)
        {
            try
            {
                File.WriteAllLines(outputFilePath, input);
                return Maybe<string>.CreateSuccess("");
            }
            catch 
            {
                return Maybe<string>.CreateFailure();
            }
        }
    }

    public static class PhoneNumberParser
    {
        public static bool TryParsePhoneNumbers(string regexPattern, string input, out string[] phoneNumbers)
        {
            if (regexPattern is null || input is null)
            {
                phoneNumbers = new string[] { "" };
                return false;
            }
            var regex = new Regex(regexPattern);
            MatchCollection matches = regex.Matches(input);
            phoneNumbers = new string[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                phoneNumbers[i] = matches[i].ToString();
            }
            return true;
        }
    }
}
