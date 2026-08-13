public class CyclingActivity : Activity
{
    private double _speed;

    public CyclingActivity(DateTime date, int lengthInMinutes, double speed) : base(date, lengthInMinutes)
    {
        _speed = speed;
    }

    public override double GetSpeed()
    {
        return _speed;
    }
    public override double GetDistance()
    {
        double distance = (_speed / 60) * GetLengthInMinutes();
        return distance;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}