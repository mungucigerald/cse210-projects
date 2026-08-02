// Collects as many responses as they can list oo a prompt within the set duration
public class ListingActivity : Activity
{
    // Pool of prompts for the activity
    private List<string> _prompts = new()
    {
        "Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people tha you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?", "What are some of your favorite things to do?", "What are some your favorite places to visit?", "What are some of your favorite memories?"
    };

    // Stores used prompts so they aren't repeated until all are shown.
    private List<string> _usedPrompts = new();

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {

    }

    public void RunListingActivity()
    {
        DisplayStartMessage();

        Console.WriteLine("List as many responses as you can to the following prompt:\n");
        Console.WriteLine(GetRandomPrompt());
        Console.WriteLine("\nYou may begin in...");
        ShowCountDown(5);
        Console.WriteLine();

        List<string> userResponses = GetUserList();
        Console.WriteLine($"\nYou listed {userResponses.Count} items!");

        DisplayEndMessage();
    }

    private string GetRandomPrompt()
    {
        return GetRandomItem(_prompts, _usedPrompts);
    }

}