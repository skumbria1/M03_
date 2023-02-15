using System;
using System.IO;
using Maybe;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            if (AverageWordLength
                .TryCalculate("John said, \"Get the phone...Now!\"", out double calculateResult))
            {
                Console.WriteLine(calculateResult);
            }

            if (RepeatingCharacters
                .TryDoubleTheCharacters("omg i love shrek", "o kek", 
                out string RepeatingCharactersResult))
            {
                Console.WriteLine(RepeatingCharactersResult);
            }

            if (SumOfBigNumbers.TryCalculate("999", "999", out string SumOfBugNumbersResult))
            {
                Console.WriteLine(SumOfBugNumbersResult);
            }

            if (StringWordsReverser.TryReverseWords(
                "The greatest victory is that which requires no battle", 
                out string StringWordsReverserResult))
            {
                Console.WriteLine(StringWordsReverserResult);
            }

            PhoneNumberParserDemonstration();
            
        }

        static void PhoneNumberParserDemonstration()
        {
            string regexPattern = @"(\+\d \(\d{3}\) \d{3}-\d{2}-\d{2})|" +
                                  @"(\d \d{3} \d{3}-\d{2}-\d{2})|" +
                                  @"(\+\d{3} \(\d{2}\) \d{3}-\d{4})";
            string workingDirectory = Environment.CurrentDirectory;
            string inputFilePath = Directory.GetParent(workingDirectory)
                .Parent.Parent.FullName + "\\Text.txt";
            var fileReaderWriter = new FileIO();
            var readResult = fileReaderWriter.Read(inputFilePath);
            if (readResult is Success<string> success)
            {
                if (PhoneNumberParser
                    .TryParsePhoneNumbers(regexPattern, success.Value, out string[] phoneNumbers))
                {
                    string outputFilePath = Directory.GetParent(workingDirectory)
                        .Parent.Parent.FullName + "\\Numbers.txt";
                    fileReaderWriter.Write(outputFilePath, phoneNumbers);
                }
            }
        }
    }
}
