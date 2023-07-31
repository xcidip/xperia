using System;

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
            Console.Read();
        }
    }
}