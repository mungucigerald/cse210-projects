using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    // Constructor used to create a brand new simple goal.
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    // Constructor used to reload goal from a saved file. Restores current state.
    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        _isComplete = true;
        return Points;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
        {
        return $"Simple Goal: {ShortName}, {Description}, {Points}, {_isComplete}";
    }

}