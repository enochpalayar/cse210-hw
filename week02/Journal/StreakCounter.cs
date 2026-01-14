// Stretch Challenge: I did StreakCounter like from the Gospel Library to encourage journaling.
public class StreakCounter
{
    private int _streakCount = 0;   
    private string _lastEntryDate = ""; 

    // Call this whenever a new entry is added
    public void UpdateStreak(string currentDate)
    {
        if (_lastEntryDate == "")
        // When first entry starts streak
        {
            _streakCount = 1; 
        }
        else
        {
            DateTime lastDate = DateTime.Parse(_lastEntryDate);
            DateTime today = DateTime.Parse(currentDate);

            if (today == lastDate.AddDays(1))
            // This make streak goes up
            {
                _streakCount++; 
            }
            else if (today != lastDate)
            //This resets the straek 
            {
                _streakCount = 1; 
            }
        }
        _lastEntryDate = currentDate; 
    }

    public void DisplayStreak()
    {
        Console.WriteLine($"Your current journaling streak: {_streakCount} day(s) in a row!");
    }
}
