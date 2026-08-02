using System;
using System.Threading;
using System.Collections.Generic;
// Base class for all the activities. Handles the state and behavior that are shared accross every activity so the derived class can implement their own Run methods 
public class Activity
{
    // Private fields ensure derived classes and outside code can't directly affect these variables
    private string _name;
    private string _description;
    private int _duration;

    // Derived classes can pass up their name and description with this constructor so each activity can specify the unique details. 
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Public getter reads the duration for the derived classes without exposing the field
    public int GetDuration()
    {
        return _duration;
    }

    // Shared start sequence for all activities, shows the name and description and asks for the duration with pauses.
    public void DisplayStartMessage()
    {
        Console.WriteLine($"Welcome to the {_name}\n");
        Thread.Sleep(1000);
        Console.WriteLine(_description);
        Thread.Sleep(1000);
        Console.Write("\nHow long, in seconds, would you like for your sesssion? ");
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();
        Thread.Sleep(1000);
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.Clear();
    }

    // Shared end message for derived classes
    public void DisplayEndMessage()
    {
        Console.WriteLine("Well Done!");
        ShowSpinner(5);
        Console.WriteLine($"You have completed {_duration} seconds of the {_name}");
        ShowSpinner(2);
    }

    // Pause with animation that cycles through spinner chracters 
    public void ShowSpinner(int seconds)
    {
        List<string> spinnerChars = new() { "|", "/", "—", "\\", "|", "/", "—", "\\" };
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(spinnerChars[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i = (i + 1) % spinnerChars.Count;
        }
    }

    // Pause with animation that counts down numbers 
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    // Returns an option from a collection, also tracks the used options to control repitition of option.
    protected String GetRandomItem(List<string> pool, List<string> usedItems)
    {
        Random _random = new();
        if (usedItems.Count == pool.Count)
        {
            usedItems.Clear();
        }

        string choice;
        do
        {
            choice = pool[_random.Next(pool.Count)];
        } while (usedItems.Contains(choice));
        usedItems.Add(choice);
        return choice;
    }

    // Saves a list from the user input until the duration of the session expires.
    protected List<string> GetUserList()
    {

        List<string> userList = new();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");

            string input = Console.ReadLine();

            // Skip blank entries to avoid adding whitespace to list.
            if (!string.IsNullOrWhiteSpace(input))
            {
                userList.Add(input);
            }
        }
        return userList;
    }


}