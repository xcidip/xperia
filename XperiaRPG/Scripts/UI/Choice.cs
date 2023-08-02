using System;
using System.Text.RegularExpressions;

namespace XperiaRPG.Scripts.UI
{
    public static class Choice
    {
        public static int NumberRangeValidation(int bottom, int top)
        {
            var isValidInput = false;
            var userInput = 0;
            Console.Write("\n");

            while (!isValidInput)
            {
                Console.Write($"Please enter a number between {bottom} and {top}: ");
                var input = Console.ReadLine();

                if (int.TryParse(input, out userInput))
                {
                    if (userInput >= bottom && userInput <= top)
                    {
                        isValidInput = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            return userInput;
        }

        public static string NameValidation()
        {
            Console.Write("\n");

            while (true)
            {
                Console.Write($"Please enter your character's name: ");
                var input = Console.ReadLine();

                var tooLong = input.Length > 40;
                var hasNumbers = ContainsNumbers(input);

                if (tooLong)
                {
                    Console.WriteLine("Dont troll the length of your name xD");
                }
                else if (hasNumbers)
                {
                    Console.WriteLine("Your name can't contain any numbers!");
                }
                else
                {
                    return input;
                }


            }
            
        }

        private static bool ContainsNumbers(string input)
        {
            // Regular expression pattern to match any digit (0-9) in the input string.
            const string pattern = @"\d";
            // Use Regex.IsMatch to check if the pattern is found in the input string.
            return Regex.IsMatch(input, pattern);
        }
        
        public static char YesNoValidation()
        {
            char userInput;
            Console.Write("\n");

            while (true) 
            {
                Console.Write("Please enter (y/n):");
                var input = Console.ReadLine();

                if (char.TryParse(input, out userInput)) 
                {
                    if (userInput == 'y' || userInput == 'n')
                    {
                        break;
                    } 
                }
                else 
                {
                    Console.WriteLine("Invalid input!");
                }

            }
            return userInput;
        }

        public static void PressEnter()
        {
            Console.Write("\nPress ENTER to continue:");
            Console.ReadLine();
        }
    }
}