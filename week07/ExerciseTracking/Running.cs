public class Running:Activity
{
    private double _distanceKm;

    public Running(DateTime Date, int lengthInMinutes, double distanceKm) : base(Date, lengthInMinutes)
    {
        _distanceKm = distanceKm;
    }

    public override double GetDistance()
    {
        return _distanceKm;
    }
    public override double GetSpeed()
    {
        return (GetDistance() / GetLengthInMinutes() * 60);
    }
    public override double GetPace()
    {
        return GetLengthInMinutes()/ GetDistance();
    }

}