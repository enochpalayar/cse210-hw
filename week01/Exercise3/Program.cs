using System;
using System.Runtime.CompilerServices;
using System.Text;

class Program
{
    static void Main(string[] args)

    {
        /* CORE REQUIREMENT #1

        Console.Write("What is the magic number? ");
        int magicNumber = int.Parse(Console.ReadLine());

        Console.Write("What is your guess? ");
        int guess = int.Parse(Console.ReadLine());

        if (guess < magicNumber)
        {
            Console.WriteLine("Higher");
        }
        else if (guess > magicNumber)
        {
            Console.WriteLine("Lower");
        }
        else
        {
            Console.WriteLine("You guessed it!");
        }
        */

        /* CORE REQUIREMENT #2
        
        Console.Write("What is the magic number? ");
        int magicNumber = int.Parse(Console.ReadLine());

        int guess = -1;

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
             Console.WriteLine("You guessed it!");
            }

            */

        /* CORE REQUIREMENT #3 */

        string playAgain = "yes"; //stretch challenge: playAgain loop

        while (playAgain.ToLower() == "yes") //yes lowercase to read
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int numberGuess = -1;
            int guessCount = 0; //variable for counting user guesses

            Console.WriteLine("Guess the magic number (between 1 and 100)!");

            while (numberGuess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string userGuess = Console.ReadLine();
                numberGuess = int.Parse(userGuess);
                guessCount++; //strectch challenge: count guesses

                if (numberGuess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (numberGuess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();

        }
        Console.WriteLine("Thanks for playing!");
    }
}