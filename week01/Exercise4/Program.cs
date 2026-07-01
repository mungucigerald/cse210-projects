using System;
using System.Diagnostics;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numberSeries = new List<int>();
        int stop = 0;
        int number = -1;
        Console.WriteLine("Enter a list of numbers, type 0 when finished. ");

        while (number != stop)
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            if (number != stop)
            {
                numberSeries.Add(number);
            }
        }

        int count = numberSeries.Count();
        int sum = 0;
        int largest = -1;
        int smallest = 9999;

        foreach (int num in numberSeries)      
        {
            sum += num;

            if (num > largest)
            {
                largest = num;
            }

            if (num > 0 && num < smallest)
            {
                smallest = num;
            }
        }
        Console.WriteLine($"The sum is: {sum}.");

        int average = sum / count;
        Console.WriteLine($"The average : {average}.");
        Console.WriteLine($"The largest number : {largest}.");
        Console.WriteLine($"The smallest positive : {smallest}.");

        Console.WriteLine("The sorted list is:");
        numberSeries.Sort(); 
        foreach (int n in numberSeries)
        {
            Console.WriteLine(n);
        }
    }
}