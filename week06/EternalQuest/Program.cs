using System;
// Tracks varying goals namely Simple, Eternal & Checklist goals and awards points when recorded.
// Exceeded requirements by including a leveling system to increase the user's level with every 1000points earned.
// Method used to validate numeric input and valid menu choice & goal selection to gaurd against crashing from bad input.
// Goals saved with the corresponding type tagged.
class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new();
        goalManager.Start();
    }
}