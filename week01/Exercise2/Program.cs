using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your Percentage Score. ");
        int score = int.Parse(Console.ReadLine());
        
        string letter;
        
        if (score >= 90)
        {
            letter = "A";
        }
        else if (score >= 80)
        {
            letter = "B";
        }
        else if (score >= 70)
        {
            letter = "C";
        }
        else if (score >= 60)
        {
            letter = "D";
        }
        else 
        {
            letter = "F";
        }
       

        if (letter != "F")
        {
            if (score % 10 >= 7)
            {
                letter += "+";
            }
            else if (score % 10 <= 3)
            {
                letter += "-";
            }
        }
        Console.WriteLine(letter);


        if (score >= 70)
        {
            Console.WriteLine("You passed this class.");
        }
        else
        {
            Console.WriteLine("You can do better. Please retake this class.");
        }
    }
}