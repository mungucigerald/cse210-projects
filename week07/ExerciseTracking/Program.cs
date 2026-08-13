using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new()
        {
            new RunningActivity(new DateTime(2026, 08, 10), 30, 3.0),
            new CyclingActivity(new DateTime(2026, 08, 10), 45, 12.5),
            new SwimmingActivity(new DateTime(2026, 08, 10), 30, 40),
            new WalkingActivity(new DateTime(2026, 08, 10), 60, 3.5)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

        Console.WriteLine();
        PrintAggregateReport(activities);

    }

    // Polymorphism lets us process different activities regardless of type
    static void PrintAggregateReport(List<Activity> activities)
    {
        double totalDistance = 0;
        Activity fastest = activities[0];

        foreach (Activity activity in activities)
        {
            totalDistance += activity.GetDistance();

            if (activity.GetSpeed() > fastest.GetSpeed())
            {
                fastest = activity;
            }
        }

        Console.WriteLine($"Total distance across all activities: {totalDistance:F1} kilometers");
        Console.WriteLine($"Fastest Activity: {fastest.GetType().Name} at {fastest.GetSpeed():F1} km/h");
    }
}