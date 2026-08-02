// Tracks the nuber of times each activity has been completed and saves that history to text file. 
public static class ActivityLog
{
    private static Dictionary<string, int> _activityCounts = new(); //Key = activity class name, Value = run count.
    private const string LogFile = "activity_log.txt";

    // Called once after an activity is complete, activity is added to the dictionary with the count increasing for every additional log 
    public static void RecordRun(string activityName)
    {
        if (!_activityCounts.ContainsKey(activityName))
            _activityCounts[activityName] = 0;
        _activityCounts[activityName]++;
    }

    // Write the current log to the log File, with one line per activity
    public static void SaveLog()
    {
        var lines = _activityCounts.Select(kv => $"{kv.Key},{kv.Value}");
        File.WriteAllLines(LogFile, lines);
    }

    // Reads the log counts from a previous session. Escapes if the log file does not exist 
    public static void LoadLog()
    {
        if (!File.Exists(LogFile)) return;

        _activityCounts.Clear();
        foreach (string line in File.ReadAllLines(LogFile))
        {
            string[] parts = line.Split(",");
            _activityCounts[parts[0]] = int.Parse(parts[1]);
        }
    }

    // Prints a simple summary, applied when the user quits the program.
    public static void DisplaySummary()
    {
        Console.WriteLine("\n------Activity History:------");
        foreach (var kv in _activityCounts)
        {
            Console.WriteLine($"{kv.Key}: {kv.Value} time(s)");
        }
    }

}