public class CheckListGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    // Constructor for brand new checklist goal.
    public CheckListGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    // Constructor for reloading goal saved in file. Restores current progress.
    public CheckListGoal(string name, string description, int points, int target, int bonus, int amountCompleted) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;
        int totalPoints = Points;

        if (_amountCompleted == _target)
        {
            totalPoints += _bonus;
        }

        return totalPoints;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string check = IsComplete() ? "[X]" : "[ ]";
        return $"{check}, {ShortName} {Description} --- Completed {_amountCompleted / _target}";
    }

    public override string GetStringRepresentation()
    {
        return $"Checklist Goal: {ShortName}, {Description}, {Points}, {_target}, {_bonus}, {_amountCompleted}";
    }
}