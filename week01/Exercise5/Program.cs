using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = UserNameInput();
        int userNumber = UserNumberInput();

        int squared = SquareNumber(userNumber);
        
        DisplayResult(userName, squared);
    }
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }

        static string UserNameInput()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }
        static int UserNumberInput()
        {
            Console.Write("Please enter your favorite number: ");
            int number = int.Parse(Console.ReadLine());
            return number;
        }

        static int SquareNumber(int number)
        {
            return number * number;
        }
        static void DisplayResult(string name, int squaredNumber)
        {
            Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
        }
}