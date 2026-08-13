public class SwimmingActivity : Activity
{
    private int _laps;
    private const double LapLengthInMeters = 50;

    public SwimmingActivity(DateTime date, int lengthInMinutes, int laps) : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        double km = _laps * LapLengthInMeters / 1000;
        return km;
    }

    public override double GetSpeed()
    {
        return GetDistance() / GetLengthInMinutes() * 60;
    }

    public override double GetPace()
    {
        return GetLengthInMinutes() / GetDistance();
    }
}