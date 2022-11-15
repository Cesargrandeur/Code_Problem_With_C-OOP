using System;
namespace GuessGame {
    /*
A guessing game program where the user has to guess a secret number and has only 3 tries. The program provides the user
with hints whether the number inputed is too high (when the value is greater than secret number) or too low 
in a reverse case. when the same number is inputed consecutively, it counts it as one try.
*/
    public class GuessGameSolution
    {
        public void GuessNumber()
        {
            Random rnd = new Random();
            // Getting a secret number for the game from random numbers
            int secretNum = rnd.Next(1, 21);
            int allowedTryCount = 3;
            int lastTryNum = 0;
            int tryCount = 0;
            // Printing the game title
            Console.WriteLine("===== GUESS GAME =====");

            // Making sure that user plays the game according to number of trails.
            while (tryCount < allowedTryCount)
            {

                Console.Write("Guess a number within the range of 1 - 20: ");
                string strNum = Console.ReadLine()!;
                Console.WriteLine();


                bool isValid = false;
                string message = "";
                var num = 0;
                // Catching exceptions, when an invalid number is entered
                try
                {
                    num = int.Parse(strNum);
                }
                catch
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }
                // Making sure that the number entered is non-negative and not greater than 20
                if (num < 1 || num > 20)
                {
                    message = $"Number out of range!";
                }
                else
                {
                    // Checking if the number entered is the same as previous and incrementing the count if they are different
                    if (num != lastTryNum)
                    {
                        tryCount += 1;
                    }
                    lastTryNum = num;


                    if (num != secretNum)
                    {
                        message = $"Wrong number! The number you entered is too {(num < secretNum ? "small" : "large")} You have {allowedTryCount - tryCount} try(s) left";
                    }
                    else
                    {
                        message = $"Correct! You win!!!";
                        isValid = true;
                    }
                }
                // Printing out the output of the game
                if (!isValid)
                {
                    if (tryCount == allowedTryCount)
                    {
                        Console.WriteLine("Sorry! You have no trys left");
                    }
                    else
                    {
                        Console.WriteLine(message);
                    }
                }
                else
                {
                    Console.WriteLine(message);
                    break; // Breaking out of the loop when we get the secret number and still have some trials
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GuessGameSolution guess = new GuessGameSolution();
            guess.GuessNumber();
        }
    }
}

