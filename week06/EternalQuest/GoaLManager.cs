
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new();
        _score = 0;
    }

    public void Start()
    {
        int choice = -1;
        while (choice != 6)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options");
            Console.WriteLine("     1. Create a new Goal");
            Console.WriteLine("     2. List Goals");
            Console.WriteLine("     3. Save Goals");
            Console.WriteLine("     4. Load Goals");
            Console.WriteLine("     5. Record Event");
            Console.WriteLine("     6. Quit");
            Console.Write("Select a choice from the menu: ");

            string input = Console.ReadLine();
            if (!int.TryParse(input, out choice))
            {
                choice = -1;
            }

            Console.WriteLine();
            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoalDetails();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            Console.WriteLine();
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points. {GetLevelDescription()}");
    }

    public string GetLevelDescription()
    {
        int level = _score / 1000 + 1;
        return $"(Level: {level})";
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("     1. Simple Goal");
        Console.WriteLine("     2. Eternal Goal");
        Console.WriteLine("     3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string goalChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string goalName = Console.ReadLine();

        Console.Write("Briefly describe this goal. ");
        string goalDescription = Console.ReadLine();

        Console.Write("What is the most amount of points associated with this goal? ");
        int points = ReadInt();

        switch (goalChoice)
        {
            case "1":
                _goals.Add(new SimpleGoal(goalName, goalDescription, points));
                Console.WriteLine("Simple goal created!");
                break;
            case "2":
                _goals.Add(new EternalGoal(goalName, goalDescription, points));
                Console.WriteLine("Eternal goal created!");
                break;
            case "3":
                Console.Write("How many times does this goal need to be acclomplished for a bonus?");
                int target = ReadInt();
                Console.WriteLine("What is the bonus for acclomplishing it that many times?");
                int bonus = ReadInt();
                _goals.Add(new CheckListGoal(goalName, goalDescription, points, target, bonus));
                Console.WriteLine("Checklist goal created!");
                break;
            default:
                Console.WriteLine("Invalid goal type. No goal created.");
                break;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int choice = ReadInt();

        if (choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid goal selected.");
            return;
        }

        Goal goal = _goals[choice - 1];
        int pointsEarned = goal.RecordEvent();
        _score += pointsEarned;

        Console.WriteLine($"Congrtulations! You earned {pointsEarned} points!");
        if (goal.IsComplete())
        {
            Console.WriteLine("You have completed this goal!");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the file name for the goal file!");
        string filename = Console.ReadLine();

        using (StreamWriter outputfile = new(filename))
        {
            outputfile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputfile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goal Saved.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the file name for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("That file does not exist!");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string type = parts[0];
            string[] data = parts[1].Split(",").Select(d => d.Trim()).ToArray();

            switch (type)
            {
                case "Simple Goal":
                    _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
                    break;
                case "Eternal Goal":
                    _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                    break;
                case "Checklist Goal":
                    _goals.Add(new CheckListGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5])));
                    break;
                default:
                    Console.WriteLine($"Unrecognized goal on line {i + 1}, skipping.");
                    break;

            }
        }
        Console.WriteLine("Goals loaded.");
    }

    private int ReadInt()
    {
        int result;
        while (!int.TryParse(Console.ReadLine(), out result))
        {
            Console.Write("Please enter a valid number: ");
        }
        return result;
    }

}