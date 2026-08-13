public class RunningActivity : Activity
{
    private double _distance;

    public RunningActivity(DateTime date, int lengthInMinutes, double distance) : base(date, lengthInMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        double speed = _distance / GetLengthInMinutes() * 60;
        return speed;
    }

    public override double GetPace()
    {
        double pace = GetLengthInMinutes() / _distance;
        return pace;
    }

}