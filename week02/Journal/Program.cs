using System;
// Exceeded requirements by;
// 1. Prevention of same prompt from being used twice in a row.
// 2. Recorded the time data alongside the date for every entry.
// 3. Saved and Loaded the entries in a proper CSV format including a header row and correctly parsing the commas, qoutes and new lines allowing the file to open cleanly in Excel

class Program
{
    static void Main(string[] args)
    {
        // Initiate new Journal object
        Journal journal = new();
        // Initiate Prompt generator object
        PromptGenerator promptGenerator = new();

        // Initiate while loop with boolean variable 
        bool running = true;
        while (running)
        {
            Console.WriteLine("Please select one of the following option:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            // Perform logic operations and show output
            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();
                string date = DateTime.Now.ToShortDateString();
                string time = DateTime.Now.ToShortTimeString();
                Entry newEntry = new(date, time, prompt, response);
                journal.AddEntry(newEntry);
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Filename: ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("Filename: ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
            else if (choice == "5")
            {
                running = false;
            }

        }
    }
}