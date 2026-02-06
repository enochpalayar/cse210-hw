using System;

class Program
{
    static void Main(string[] args)
    {
        /*Exceeding Requirements:
        ~ To show creativity I made prompts/questions to not repeat until all have been used once on the session/activity.
        It shows a message that all questions has been used after doing the activity in a prompt and will load and dipslay the end message and go back to main menu.
        It improves user experience by avoiding repetition in Listing and Reflecting activities. ~*/
        BreathingActivity breathing = new BreathingActivity();
        ReflectingActivity reflecting = new ReflectingActivity();
        ListingActivity listing = new ListingActivity();

        bool running = true;

        while (running)
        {
            Console.WriteLine("\nMindfulness Program");
            Console.WriteLine("  1. Breathing Activity");
            Console.WriteLine("  2. Reflecting Activity");
            Console.WriteLine("  3. Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Clear();
                breathing.Run();
            }
            else if (choice == "2")
            {
                Console.Clear();
                reflecting.Run();
            }
            else if (choice == "3")
            {
                Console.Clear();
                listing.Run();
            }
            else if (choice == "4")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again and please choose a valid number.");
            }
        }
    }
}
