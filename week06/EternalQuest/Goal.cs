using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        private string _name;
        private string _description;
        private int _points;

        public string Name => _name;
        public string Description => _description;
        public int Points => _points;

        protected Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
        }

        // Returns points earned for recording an event
        public abstract int RecordEvent();

        // Is the goal complete?
        public abstract bool IsComplete();

        // Display status string for this goal
        public abstract string GetStatus();

        // Serialize to string for saving
        public abstract string Serialize();
    }
}
