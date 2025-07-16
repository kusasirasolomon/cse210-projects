using System;
using System.Collections.Generic;
using System.IO;

// Represents a single journal entry
public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }

    public Entry(string prompt, string response)
    {
        Prompt = prompt;
        Response = response;
    }

    public override string ToString()
    {
        return $"Prompt: {Prompt}\nResponse: {Response}\n";
    }
}

// Manages a collection of journal entries
public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found.\n");
            return;
        }

        Console.WriteLine("Your Journal:\n");
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.ToString());
        }
    }

    public void Save(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine(entry.Prompt);
                    writer.WriteLine(entry.Response);
                    writer.WriteLine("---");
                }
            }

            Console.WriteLine("Journal saved.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}\n");
        }
    }

    public void Load(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        try
        {
            _entries.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string? prompt;
                string? response;
                while ((prompt = reader.ReadLine()) != null &&
                       (response = reader.ReadLine()) != null &&
                       reader.ReadLine() != null) // skip separator
                {
                    _entries.Add(new Entry(prompt, response));
                }
            }

            Console.WriteLine("Journal loaded.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}\n");
        }
    }
}

class Program
{
    private static readonly List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    private static readonly Random rand = new Random();

    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal");
            Console.WriteLine("4. Load the journal");
            Console.WriteLine("5. Quit");
            Console.Write("Select an option (1-5): ");

            string? input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    WriteEntry(journal);
                    break;
                case "2":
                    journal.Display();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string? saveFile = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(saveFile))
                        journal.Save(saveFile.Trim());
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string? loadFile = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(loadFile))
                        journal.Load(loadFile.Trim());
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.\n");
                    break;
            }
        }

        Console.WriteLine("Program ended.");
    }

    static void WriteEntry(Journal journal)
    {
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine() ?? "";
        journal.AddEntry(new Entry(prompt, response));
        Console.WriteLine("Entry saved.\n");
    }
}
