using System;


class Program
{
    static void Main(string[] args)
    {
        /* Exceeding Requirements:
        ~ To show creativity I added a Leveling System with some fun titles. It is displayed at the 
        start of the program and also eveyrtime the user update their record event. Levels are based 
        on total score achieved (500, 2000, 5000, 10000). The Titles I made are Beginner, Explorer, 
        Champion, Master, Eternity Seeker.*/

        Console.WriteLine("Welcome to the Eternal Quest Program!");
        GoalManager manager = new GoalManager();
        manager.CheckLevel();
        manager.Start();
    
        Console.WriteLine("Thank you for playing the Eternal Quest!");
    }
}