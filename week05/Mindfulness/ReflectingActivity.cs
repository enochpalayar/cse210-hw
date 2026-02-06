public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<string> _usedPrompts;   //This tracks used prompts from the session/activity.
    private List<string> _availableQuestions; // This resets questions per prompt
    public ReflectingActivity(): base("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "How did you feel when it was complete?",
            "What did you learn about yourself?",
            "How can you apply this experience in the future?"
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

        _availableQuestions = new List<string>(_questions); 

        return prompt;
    }

    private string GetRandomQuestion()
    {
        if (_availableQuestions.Count == 0)
        {
            return null;
        }

        Random rand = new Random();
        int index = rand.Next(_availableQuestions.Count);
        string question = _availableQuestions[index];

        _availableQuestions.RemoveAt(index); 
        return question;
    }

    private void DisplayPrompt(string prompt)
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();
    }

    private void DisplayQuestions(DateTime endTime)
    {
        bool askedAtLeastOne = false;

        while (DateTime.Now < endTime || !askedAtLeastOne)
        {
            string question = GetRandomQuestion();
            if (question == null)
            {
                Console.WriteLine();
                Console.WriteLine("Great Job! All questions have been used.");
                ShowSpinner(3);
                return;
            }

            Console.Write($"> {question} ");
            ShowSpinner(10); 
            Console.WriteLine();

            askedAtLeastOne = true;
        }
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        if (prompt == null)
        {
            return;
        }

        DisplayPrompt(prompt);

        Console.WriteLine("\nNow ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowSpinner(3);
        Console.Clear();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        DisplayQuestions(endTime);

        DisplayEndingMessage();
    }
}
