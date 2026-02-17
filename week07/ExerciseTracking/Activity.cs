public abstract class Activity
{
    private DateTime _date;
    private int _lengthInMinutes;

    public Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    public DateTime GetDate()
    {
        return _date;
    }
    public int GetLengthInMinutes()
    {
        return _lengthInMinutes;
    }
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{GetDate():dd MMM yyyy} {this.GetType().Name} ({GetLengthInMinutes()} min) - Distance {GetDistance():0.0} km, Speed {GetSpeed():0.0} kph, Pace {GetPace():0.00} min per km";
    }

}