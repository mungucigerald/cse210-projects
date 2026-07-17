using System;
// Exceeded Requirements:
// 1: A ScriptureLibrary class that loads scriptures from a text file and provides a method to retrieve a random scripture. 
// The class uses a list of tuples to store the reference and text of each scripture, and it includes logic to parse the text file and create Reference objects for each scripture.
// The GetRandomScripture method returns a new Scripture object with a random reference and text from the library.
// 2: Random Selection of Scriptures: The ScriptureLibrary class uses a Random object to select a random scripture from the list of loaded scriptures. 
// This allows the user to practice memorizing different scriptures each time they run the program.
// 3: Hint Feature: The Scripture class includes a RevealHint method that reveals a random hidden word in the scripture.

class Program
{
    // The main entry point of the application. Initializes the ScriptureLibrary, manages the practice session, and handles user input for hiding words or quitting the program.
    // Runs a loop that continues until the user decides to quit, allowing them to practice memorizing scriptures by hiding words and revealing hints.
    // The Practice method is called to manage the hiding and revealing of words in the scripture, and it returns a boolean indicating whether the user wants to quit or continue.
    static void Main(string[] args)
    {
        // Initialize the ScriptureLibrary with the path to the scriptures file
        ScriptureLibrary Library = new ScriptureLibrary("scriptures.txt");
        bool keepRunning = true;

        while (keepRunning)
        {
            // Get a random scripture from the library
            Scripture scripture = Library.GetRandomScripture();
            bool userWantsToQuit = Practice(scripture);

            if (userWantsToQuit)
            {
                break; // Exit the loop if the user wants to quit
            }

            // Prompt the user to continue or quit after completing the practice session
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            string response = Console.ReadLine().Trim().ToLower();
            if (response == "quit")
            {
                keepRunning = false;
                Console.WriteLine("Goodbye!");
            }

        }

        // Runs the hide and reveal words practice session for the given scripture. 
        // Returns true if the user wants to quit or complete the session, otherwise false.
        static bool Practice(Scripture scripture)
        {

            while (true)
            {
                // Clear the console and display the current state of the scripture and reference.
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());

                // Check if all words are hidden. If they are, display a message and exit the loop.
                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("All words are hidden. Press any key to exit.");
                    Console.ReadKey();
                    return false; // Return false to indicate that the user does not want to quit
                }

                // Prompt the user to press Enter to hide a word or type "quit" to exit.
                Console.WriteLine("Press Enter to hide more words or type 'quit' to exit. Type 'hint' to reveal one word.");
                string input = Console.ReadLine();

                // If the user types "quit", return true to indicate that they want to quit.
                if (input.ToLower() == "quit")
                {
                    return true; // Return true to indicate that the user wants to quit
                }
                else if (input.ToLower() == "hint")
                {
                    // Reveal a hint if the user types "hint"
                    scripture.RevealHint();
                }
                else
                {
                    // Hide 3 random words each time Enter is pressed
                    scripture.HideRandomWords(3);
                }

            }

        }
    }
}
