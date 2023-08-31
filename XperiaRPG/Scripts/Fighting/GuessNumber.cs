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

            Console.WriteLine("Welcome to the Guessing Game!");
            Console.WriteLine("Try to guess the secret secretNumber between 1 and 100.");

            var attempts = 0;

            while (true)
            {
                Console.Write("Enter your guess: ");
                var guess = Choice.NumberRangeValidation(1, 100);

                attempts++;
                
                if (guess == secretNumber)
                {
                    Console.WriteLine($"Congratulations! You guessed the secret secretNumber {secretNumber} in {attempts} attempts.");
                    break;
                }

                HighOrLow(secretNumber, guess);
            }
        }
        public void HighOrLow(int secretNumber, int guess)
        {
            if (guess < secretNumber) { Console.WriteLine("Too low! Try again."); return; }
            Console.WriteLine("Too high! Try again.");
        }
    }
}
