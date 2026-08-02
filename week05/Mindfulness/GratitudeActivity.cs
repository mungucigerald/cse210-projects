using System;
using System.Collections.Generic;
using System.IO;

// This activity has the user list things they are grateful for and saves the list to a text file.
public class GratitudeActivity : Activity
{
    public GratitudeActivity() : base("Gratitude Journal", "This activity will help you reflect on the things you are grateful for by writing them down.") { }

    public void RunGratitudeActivity()
    {
        DisplayStartMessage();

        // GetUserList() loops internally until the set duration runs out.
        List<string> gratitudeList = GetUserList();
        File.AppendAllLines("gratitude_log.txt", gratitudeList);
        Console.WriteLine($"\nYou wrote down {gratitudeList.Count} things you're grateful for.");
        DisplayEndMessage();
    }
}