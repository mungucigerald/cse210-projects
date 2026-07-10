using System;

public class PromptGenerator
{
    // Initialize a list of prompts to choose from
    public List<string> _prompts = new()
    {
       "Who was the most interesting person I interacted with today?",
       "What was the best part of my day?",
       "How did I see the hand of the Lord in my life today?",
       "What was the strongest emotion I felt today?",
       "If I had one thing I could do over today, what would it be?"
    };
    // Initialize random field, this will be used to ensure return of a random result
    public Random _random = new();
    // Initialize last prompt used variable to track prompt used to avoid repitition
    public string _lastUsedPrompt = "";

    public string GetRandomPrompt()
    {
        // Initialize a copy list of _prompts with the previous prompt excluded, maintaining the original list 
        List<string> availablePrompts = new(_prompts);
        // Prevent the removal of the only remaining prompt to avoid an empty list
        if (availablePrompts.Count > 1)
        {
            availablePrompts.Remove(_lastUsedPrompt);
        }

        int index = _random.Next(availablePrompts.Count);
        string chosenPrompt = availablePrompts[index];

        // Assign the last used prompt as the current prompt
        _lastUsedPrompt = chosenPrompt;
        return chosenPrompt; 
    }

    public void SetLastUsedPrompt(string prompt)
    {
        _lastUsedPrompt = prompt;
    }

}