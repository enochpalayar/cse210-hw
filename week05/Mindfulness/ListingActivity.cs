public class ListingActivity : Activity
{
    private int _count; 
    private List<string> _prompts;
    private List<string> _usedPrompts; // This track used prompts from the session/activity

    public ListingActivity(): base("Listing","This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _usedPrompts = new List<string>();
    }

    private string GetRandomPrompt()
    {
        if (_usedPrompts.Count == _prompts.Count)
        {
            Console.WriteLine();
            Console.WriteLine("Great Job! All prompts have been used. Returning to main menu...");
            ShowSpinner(5);
            Console.Clear();
            return null;
        }

        Random rand = new Random();
        string prompt;

        do
        {
            prompt = _prompts[rand.Next(_prompts.Count)];
        } while (_usedPrompts.Contains(prompt));

        _usedPrompts.Add(prompt); 
        return prompt;
    }

    private List<string> GetListFromUser(DateTime endTime)
    {
        List<string> responses = new List<string>();
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            responses.Add(Console.ReadLine());
        }
        return responses;
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        if (prompt == null)
        {
            return;
        } 

        Console.WriteLine();
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine("You may begin in:");
        ShowCountDown(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        _count = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            _count++;
        }

            Console.WriteLine($"You listed {_count} items!");
        DisplayEndingMessage();
    }
}
