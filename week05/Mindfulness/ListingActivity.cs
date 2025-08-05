using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private string[] prompts = {
        "List things you are grateful for.",
        "List people who have influenced you positively.",
        "List goals you want to achieve."
    };

    public ListingActivity()
    {
        name = "Listing Activity";
        description = "This activity helps you reflect by listing positive aspects of your life.";
    }

    protected override void DoActivity()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];

        Console.WriteLine($"\nPrompt: {prompt}");
        Console.WriteLine("Start listing when I say 'Go'...");
        ShowSpinner(3);
        Console.WriteLine("Go!");

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item);
            }
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");
    }
}
