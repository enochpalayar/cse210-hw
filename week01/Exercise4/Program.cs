using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            int value = int.Parse(input);

            if (value == 0)
            {
                break;
            }

            numbers.Add(value);
        }
        //Core Requirement #1: Compute the sum
        int sum = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            sum += numbers[i];
        }
        Console.WriteLine($"The sum is: {sum}");
        //Core Requirement #2: Compute the average
        double average = 0; 
        if (numbers.Count > 0)
        {
            average = (double)sum / numbers.Count;
        }
        Console.WriteLine($"The average is: {average}");

        //Core Reuirement #3: Find the maximum or largest nummber
        int max = int.MinValue;
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }
        Console.WriteLine($"The largest number is: {max}");

        // Stretch challenge: finding smallest positive number

        int? smallestPositive = null;

        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] > 0)
            {
                if (smallestPositive == null || numbers[i] < smallestPositive)
                {
                    smallestPositive = numbers[i];
                }

            }
        }
        if (smallestPositive != null)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("No positive numbers were created");
        }
        //Stretch challenge: Sort entered numbers ascending
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        for (int i = 0; i < numbers.Count; i++)
        {
            Console.WriteLine(numbers[i]);
        }

    }
}