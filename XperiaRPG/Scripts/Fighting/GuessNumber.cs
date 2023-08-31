using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XperiaRPG.Scripts.UI;

namespace XperiaRPG.Scripts.Fighting
{
    public class GuessNumber
    {
        public GuessNumber()
        {
            var random = new Random();
            var secretNumber = random.Next(1, 100); // Generates a random secretNumber between 1 and 100

            Console.WriteLine("Welcome to the number Guessing Game!");

            var attempts = 0;
            var guessList = new List<int>();

            while (true)
            {
                Console.Write("Guessed numbers: ");
                foreach (var number in guessList)
                {
                    Console.Write($"{number},");
                }
                Console.Write("\nEnter your guess: ");
                var guess = Choice.NumberRangeValidation(1, 100);
                guessList.Add(guess);

                attempts++;
                
                if (guess == secretNumber)
                {
                    Console.WriteLine($"Congratulations! You guessed the secret secretNumber {secretNumber} in {attempts} attempts.");
                    Choice.PressEnter();
                    break;
                }

                HighOrLow(secretNumber, guess);
                Choice.PressEnter();
            }
        }
        public void HighOrLow(int secretNumber, int guess)
        {
            if (guess < secretNumber) { Console.WriteLine("Too low! Try again."); return; }
            Console.WriteLine("Too high! Try again.");
        }
    }
}
