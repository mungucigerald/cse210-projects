public class WalkingActivity: Activity
{
    private double _distance;

    public WalkingActivity(DateTime date, int lengthInMinutes, double distance) : base(date, lengthInMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return _distance / GetLengthInMinutes() * 60;
    }

    public override double GetPace()
    {
        return GetLengthInMinutes() / _distance;
    }
}