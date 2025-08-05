using System;
using System.Threading;

public class ReflectingActivity : Activity
{
    private string[] prompts = {
        "Think of a time you overcame a challenge.",
        "Recall a time you helped someone in need.",
        "Remember a time you achieved something meaningful."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "What did you learn about yourself?",
        "How did it make you feel afterward?",
        "What did you do to overcome the challenge?"
    };

    public ReflectingActivity()
    {
        name = "Reflecting Activity";
        description = "This activity helps you reflect on meaningful experiences.";
    }

    protected override void DoActivity()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];

        Console.WriteLine($"\nPrompt: {prompt}");
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now consider the following questions:");

        int timePerQuestion = duration / questions.Length;

        foreach (string question in questions)
        {
            Console.WriteLine($"\n{question}");
            ShowSpinner(timePerQuestion);
        }
    }
}
