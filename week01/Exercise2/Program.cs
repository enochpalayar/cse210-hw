using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter grade percentage: ");
        string valueFromUser = Console.ReadLine();
        int gradePercentage = int.Parse(valueFromUser);

        string letter = "";
        string sign = "";

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // This is for the stretch challenge to determine sign (+ or -)
        int lastDigit = gradePercentage % 10;

        if (letter != "F")
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        if (letter == "A" && sign == "+")
        {
            sign = "";
        }


        Console.WriteLine($"Your grade is: {letter}{sign}");

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations, you passed!");
        }
        else
        {
            Console.WriteLine("Keep working hard, better luck next time.");
        }





    }
}