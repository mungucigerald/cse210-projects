public abstract class Activity
{
    private DateTime _date = DateTime.Now;
    private int _lengthInMinutes;

    public Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    //Protected accessors for derived class to use attributes for calculations
    protected DateTime GetDate()
    {
        return _date;
    }

    protected int GetLengthInMinutes()
    {
        return _lengthInMinutes;
    }

    // Abstract methods for the derived classes to implement
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Virtual method to be used by all the derived classes
    public virtual string GetSummary()
    {
        return $"{_date:dd MM yyyy} {GetType().Name} ({_lengthInMinutes} min) - " +
        $"Distance: {GetDistance():F1} kilometers, " +
        $"Speed: {GetSpeed():F1} km/h, " +
        $"Pace: {GetPace():F2} min per kilometer";
    }
}