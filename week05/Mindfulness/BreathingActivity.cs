public class BreathingActivity : Activity
{
    public BreathingActivity(): base("Breathing","This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        int inhaleSeconds = 4;   
        int exhaleSeconds = 6; 
        int cycleLength = inhaleSeconds + exhaleSeconds;

        int cycles = Math.Max(1, _duration / cycleLength);

        for (int c = 0; c < cycles; c++)
        {
            Console.WriteLine();
            Console.Write("Breathe in...");
            ShowCountDown(inhaleSeconds);
            Console.WriteLine();

            Console.Write("Breathe out...");
            ShowCountDown(exhaleSeconds);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
