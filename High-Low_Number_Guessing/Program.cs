using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High_Low_Number_Guessing
{
    class Program
    {
        static void Main(string[] args)
        {
            int secretNumber = GenerateRandomNumber(1, 50); // Generates a random number from 1-50
            string numberString = AskUserForAGuess();
            int numberGuessed = 0;
            int numberOfGuesses = 10;

            while (true) // Game session has begun
            {
                while (true)
                {

                    // Validate input
                    if (Int32.TryParse(numberString, out numberGuessed)) // Check if number is actually an integer 
                    {
                        if (IsNotWithinRange(numberGuessed)) // Check if integer is within range
                        {
                            Console.WriteLine("The value you entered is not between 1 and 50.\n");
                        }
                        else
                        {
                            break; // End validation
                        }
                    }
                    else
                    {
                        Console.WriteLine("The value you entered is not a integer.\n");
                    }
                    numberString = AskUserForAGuess();
                }

                // Check if number guessed is high, low, or correct 
                if (numberGuessed < secretNumber) 
                {
                    Console.WriteLine("Too low!");
                    numberOfGuesses--;
                    if (numberOfGuesses == 0) // Check if out of guesses
                    {
                        Console.WriteLine("You lose!\n");
                        break; // End game
                    }
                    else
                    {
                        Console.WriteLine("You have {0} guesses left.\n", numberOfGuesses);
                    }
                    numberString = AskUserForAGuess();
                }
                else if (numberGuessed > secretNumber) 
                {
                    Console.WriteLine("Too high!");
                    numberOfGuesses--;
                    if (numberOfGuesses == 0) 
                    {
                        Console.WriteLine("You lose!\n");
                        break; // End game
                    }
                    else
                    {
                        Console.WriteLine("You have {0} guesses left.\n", numberOfGuesses);
                    }
                    numberString = AskUserForAGuess();
                }
                else 
                {
                    Console.WriteLine("You are correct! You win!\n"); 
                    break; // End game
                }
            }

        }

        // Asks user for a guess and returns the string
        private static string AskUserForAGuess()
        {
            Console.Write("Please enter a guess between 1 and 50: ");
            string numberString = Console.ReadLine();
            return numberString;
        }

        // Generates a random number using a class level Random 
        // so if it's called many times, it will still have good randomness 
        static Random randomNumberGenerator = new Random();
        static int GenerateRandomNumber(int lowRange, int highRange)
        {
            int number = randomNumberGenerator.Next(lowRange, highRange);
            return number;
        }

        // Checks if a number is between 1 and 50
        private static bool IsNotWithinRange(int number)
        {
            return (number < 1 || number > 50);
        }
    }
}
