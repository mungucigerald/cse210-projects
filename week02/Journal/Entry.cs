using System;

public class Entry
{
    // Initialize the member variables
    public string _date;
    public string _time;
    public string _promptText;
    public string _entryText;

    public Entry(string date,string time, string promptText, string entryText)
    {
        _date = date;
        _time = time;
        _promptText = promptText;
        _entryText = entryText;
    }

    // Construct one CSV line for an entry
    public string GetSaveString()
    {
        return $"{CsvHelper.EscapeField(_date)},{CsvHelper.EscapeField(_time)},{CsvHelper.EscapeField(_promptText)},{CsvHelper.EscapeField(_entryText)}";
    }

    // Initialize the class method
    // Prints the entry to the console in a readable format 
    public void Display()
    {
        Console.WriteLine($"Date: {_date} @ {_time}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine(_entryText);
        Console.WriteLine(new string('-', _promptText.Length + 8));
    }
}