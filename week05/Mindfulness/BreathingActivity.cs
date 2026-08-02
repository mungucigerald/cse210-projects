// Guides the user through alternating "breathe in" / "breathe out" cycles until the chosen duration runs out. Only handles methods specific to breathing and inherits other features from the Activity base class

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on breathing")
    {
    }

    public void RunBreathingActivity()
    {
        DisplayStartMessage();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        // Alternates between IN ans OUT 
        bool breatheIn = true;

        while (DateTime.Now < endTime)
        {
            if (breatheIn)
            {
                AnimateBreath("Breathe In", 4, growing: true);
                ShowCountDown(4);
            }
            else
            {
                AnimateBreath("Breathe Out", 4, growing: false);
                ShowCountDown(4);
            }
            breatheIn = !breatheIn;
        }

        DisplayEndMessage();
    }

    // Prints a growing and shrinking row of dots for the breaths
    private void AnimateBreath(string message, int seconds, bool growing)
    {
        int totalSteps = 8;
        int[] delays = GetEasedDelays(seconds, totalSteps);

        for (int i = 0; i <= totalSteps; i++)
        {
            Console.CursorVisible = false;
            // CLear the line before redrawing to remove any old dots
            Console.Write("\r" + new string(' ', 40));
            int dotCount = growing ? i : totalSteps - i;
            Console.Write($"\r{message} {new string('.', dotCount)}");
            Thread.Sleep(delays[i]);
        }
        Console.WriteLine();
    }

    // Returns a set of frame delays that add up to the total breath duration, they delay later frames so they take longer than earlier ones
    private int[] GetEasedDelays(int totalSeconds, int steps)
    {
        int totalMs = totalSeconds * 1000;
        int[] delays = new int[steps + 1];
        int sum = 0;

        // Give each step an increasing weight ie 1, 2, 3, ...
        for (int i = 0; i <= steps; i++)
        {
            delays[i] = i + 1;
            sum += delays[i];
        }

        // Scale the weights so they sum t0 the actual breath duration in microseconds
        for (int i = 0; i <= steps; i++)
        {
            delays[i] = (int)((double)delays[i] / sum * totalMs);
        }

        return delays;
    }
}