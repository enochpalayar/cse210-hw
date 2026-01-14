using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        StreakCounter streakCounter = new StreakCounter();

        int actionNumber = 0;
        while (actionNumber != 5)
        {
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please Select on of the following Choices");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            
            string valueFromUser = Console.ReadLine();
            int.TryParse (valueFromUser, out actionNumber);

            if (actionNumber == 1)
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                Entry entry = new Entry
                {
                    _date = DateTime.Now.ToShortDateString(),
                    _promptText = prompt,
                    _entryText = response
                };
                journal.AddEntry(entry);
                //Stretch Challenge: I added streak counter to motivate user to journal
                streakCounter.UpdateStreak(entry._date);
                streakCounter.DisplayStreak();
            }
            else if (actionNumber == 2)
            {
                journal.DisplayAll();
            }
            else if (actionNumber == 3)
            {
                Console.Write("Enter filename to load: ");
                string file = Console.ReadLine();
                journal.LoadFromFile(file);
            }
            else if (actionNumber == 4)
            {
                Console.WriteLine("Enter the filename to save: ");
                string file = Console.ReadLine();
                journal.SaveToFile(file);
            }
            else if (actionNumber == 5)
            {
                Console.WriteLine("Goodbye! See you tomorrow");
            }
            else
            {
                Console.WriteLine("Invalid input. Kindly give valid Action Number");
            }

        }

    }
}