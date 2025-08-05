using System;
using System.Threading;

public class Activity
{
    protected string name;
    protected string description;
    protected int duration;

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"--- {name} ---");
        Console.WriteLine(description);
        Console.Write("\nEnter the duration of this activity in seconds: ");
        duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nGet ready...");
        ShowSpinner(3);

        DoActivity();

        Console.WriteLine("\nWell done!");
        ShowSpinner(2);
        Console.WriteLine($"\nYou have completed the {name} activity for {duration} seconds.");
        Thread.Sleep(2000);
    }

    protected virtual void DoActivity()
    {
        // To be overridden
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "/", "-", "\\", "|" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < end)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(200);
            Console.Write("\b");
            i++;
        }
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
