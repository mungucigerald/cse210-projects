using System;
using System.Collections.Generic;

// Prompts the user to think of a meaningful experience and then wals them through a series of reflective questions through the set duration.
public class ReflectionActivity : Activity
{
    // Pool of prompts for the activity
    private List<string> _prompts = new()
    {
        "Think of a time when you stood up for someone else.", "Think of a time when you did something really different.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless.", "Think of a time when you overcame a challenge.", "Think of time when you learned something new.", "Think of a time when you showed resilience in the face of adversity."
    };

    // Pool of follow up questions.
    private List<string> _questions = new()
    {
        "Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than the other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to the rest of your life?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?", "What did you learn about others through this experience?", "What did you learn about the world through this experience?"
    };

    // Shared tracker for the used prompts and questions.
    private List<string> _usedOptions = new();

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public void RunReflectionActivity()
    {
        DisplayStartMessage();
        int _duration = GetDuration();

        Console.WriteLine("Consider the following prompt: \n");
        Console.WriteLine(GetRandomPrompt());
        Console.WriteLine("\nWhen you have something in mind, press Enter to continue...");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in... ");
        ShowCountDown(5);
        Console.Clear();

        // Duration timer starts after the above thinking pause so the user reflection session last the set duration
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine(GetRandomQuestion());
            ShowSpinner(10);
            Console.WriteLine();
        }

        DisplayEndMessage();
    }

    private string GetRandomPrompt()
    {
        return GetRandomItem(_prompts, _usedOptions);
    }

    private string GetRandomQuestion()
    {
        return GetRandomItem(_questions, _usedOptions);
    }

}