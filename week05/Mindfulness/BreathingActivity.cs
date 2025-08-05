using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        name = "Breathing Activity";
        description = "This activity will help you relax by guiding you through slow breathing.";
    }

    protected override void DoActivity()
    {
        int rounds = duration / 10;
        for (int i = 0; i < rounds; i++)
        {
            Console.WriteLine("\nBreathe in...");
            Countdown(4);
            Console.WriteLine("Breathe out...");
            Countdown(6);
        }
    }
}
