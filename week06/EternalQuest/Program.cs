using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager manager = new GoalManager();

            while (true)
            {
                Console.WriteLine("\n--- Eternal Quest ---");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. Record Event");
                Console.WriteLine("3. Show Goals");
                Console.WriteLine("4. Save Goals");
                Console.WriteLine("5. Load Goals");
                Console.WriteLine("6. Quit");
                Console.Write("Choose an option: ");

                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        CreateGoal(manager);
                        break;
                    case "2":
                        RecordGoalEvent(manager);
                        break;
                    case "3":
                        manager.DisplayGoals();
                        break;
                    case "4":
                        Console.Write("Enter filename to save: ");
                        string saveFile = Console.ReadLine();
                        manager.Save(saveFile);
                        Console.WriteLine("Goals saved.");
                        break;
                    case "5":
                        Console.Write("Enter filename to load: ");
                        string loadFile = Console.ReadLine();
                        manager.Load(loadFile);
                        Console.WriteLine("Goals loaded.");
                        break;
                    case "6":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
            }
        }

        static void CreateGoal(GoalManager manager)
        {
            Console.WriteLine("Select Goal Type:");
            Console.WriteLine("1. Simple Goal (one-time)");
            Console.WriteLine("2. Eternal Goal (repeatable)");
            Console.WriteLine("3. Checklist Goal (multiple completions with bonus)");
            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter description: ");
            string desc = Console.ReadLine();

            int points = GetIntInput("Enter points awarded per event: ");

            switch (choice)
            {
                case "1":
                    manager.AddGoal(new SimpleGoal(name, desc, points));
                    Console.WriteLine("Simple goal added.");
                    break;
                case "2":
                    manager.AddGoal(new EternalGoal(name, desc, points));
                    Console.WriteLine("Eternal goal added.");
                    break;
                case "3":
                    int required = GetIntInput("Enter number of times required to complete: ");
                    int bonus = GetIntInput("Enter bonus points awarded on completion: ");
                    manager.AddGoal(new ChecklistGoal(name, desc, points, required, bonus));
                    Console.WriteLine("Checklist goal added.");
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }
        }

        static void RecordGoalEvent(GoalManager manager)
        {
            manager.DisplayGoals();
            int goalNumber = GetIntInput("Enter goal number to record event for: ") - 1;
            manager.RecordEvent(goalNumber);
        }

        static int GetIntInput(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result) && result >= 0)
                    return result;
                Console.WriteLine("Please enter a valid non-negative integer.");
            }
        }
    }
}
