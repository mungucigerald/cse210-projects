using System;

class Program
{
    static void Main(string[] args)
    {
        string action = "yes";
        while (action == "yes")
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1,101);      
            int guess = 0;
            int guessCount = 0;

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount += 1 ;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Try a higher number!");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Try a lower number!");
                }
                else            
                {
                    Console.WriteLine("You guessed it!");
                    if (guessCount > 1)
                    {
                        Console.WriteLine($"It took you {guessCount} Attempts");
                    }
                    else
                    {
                        Console.WriteLine($"It took you {guessCount} Attempt");
                    }
                    
                    Console.Write("Would you like to play again (yes/no)? ");
                    action = Console.ReadLine();
                    if (action == "no")
                    {
                        Console.WriteLine("Thank you for playing. Goodbye.");
                    }  
                }

            }
        }
        
    }
}