using System;

// ADDITIONAL ENHANCEMENTS:
//      Added another activity with a fourth class, the GratitudeActivity uses the helper method GetUSerList() from the activity base class to allow the user record things they are grateful for, each entry is then saved to the gratitude-log.txt.
//      Repitition of random prompts and questions are handled by the GetRandomItem() method in the base class.
//      An additional ActivtyLog, a static class that tracks how many times each ativity has been completed and save it to a file.
//      BreathingActivity animation with a growing and shrinking series of dots, used an eased timing curve so each frame takes progressivelt longer toward the the top of the breath ustead of a flat countdown
class Program
{
    static void Main(string[] args)
    {
        // Load any saved history from a previous run before loop starts.
        ActivityLog.LoadLog();

        string choice = "";

        while (choice != "5")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Start Gratitude Activity");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new();
                    breathingActivity.RunBreathingActivity();
                    // Get the real runtime class name for the log.
                    ActivityLog.RecordRun(breathingActivity.GetType().Name);
                    break;

                case "2":
                    ReflectionActivity reflectionActivity = new();
                    reflectionActivity.RunReflectionActivity();
                    ActivityLog.RecordRun(reflectionActivity.GetType().Name);
                    break;

                case "3":
                    ListingActivity listingActivity = new();
                    listingActivity.RunListingActivity();
                    ActivityLog.RecordRun(listingActivity.GetType().Name);
                    break;

                case "4":
                    GratitudeActivity gratitudeActivity = new();
                    gratitudeActivity.RunGratitudeActivity();
                    ActivityLog.RecordRun(gratitudeActivity.GetType().Name);
                    break;

                case "5":
                    Console.WriteLine("\nGoodBye!");
                    // Saves counts to a file and show a summary before closing.
                    ActivityLog.SaveLog();
                    ActivityLog.DisplaySummary();
                    break;

                default:
                    Console.WriteLine("\n Invalid choice. Please select a valid option from the menu.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}