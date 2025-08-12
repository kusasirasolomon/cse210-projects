using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals = new();
        private int _score = 0;
        private int _level = 1;

        public int Score => _score;
        public int Level => _level;

        public void AddGoal(Goal goal)
        {
            _goals.Add(goal);
        }

        public void DisplayGoals()
        {
            Console.WriteLine("\nYour Goals:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
            }
            Console.WriteLine($"Total Score: {_score}");
            Console.WriteLine($"Level: {_level}");
        }

        public void RecordEvent(int index)
        {
            if (index < 0 || index >= _goals.Count)
            {
                Console.WriteLine("Invalid goal number.");
                return;
            }

            int pointsEarned = _goals[index].RecordEvent();
            if (pointsEarned > 0)
            {
                _score += pointsEarned;
                Console.WriteLine($"Congrats! You earned {pointsEarned} points.");
                UpdateLevel();
            }
            else
            {
                Console.WriteLine("This goal is already completed or cannot earn points now.");
            }
        }

        private void UpdateLevel()
        {
            int newLevel = (_score / 1000) + 1;
            if (newLevel > _level)
            {
                _level = newLevel;
                Console.WriteLine($"*** Level Up! You are now level {_level}! ***");
            }
        }

        public void Save(string filename)
        {
            using StreamWriter writer = new(filename);
            writer.WriteLine(_score);
            writer.WriteLine(_level);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }

        public void Load(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("Save file not found.");
                return;
            }

            _goals.Clear();
            using StreamReader reader = new(filename);
            _score = int.Parse(reader.ReadLine());
            _level = int.Parse(reader.ReadLine());

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                switch (parts[0])
                {
                    case "SimpleGoal":
                        _goals.Add(SimpleGoal.Deserialize(parts));
                        break;
                    case "EternalGoal":
                        _goals.Add(EternalGoal.Deserialize(parts));
                        break;
                    case "ChecklistGoal":
                        _goals.Add(ChecklistGoal.Deserialize(parts));
                        break;
                    default:
                        Console.WriteLine($"Unknown goal type: {parts[0]}");
                        break;
                }
            }
        }
    }
}
