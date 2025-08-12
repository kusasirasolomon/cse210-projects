namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string name, string description, int points)
            : base(name, description, points)
        {
            _isComplete = false;
        }

        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                _isComplete = true;
                return Points;
            }
            return 0;
        }

        public override bool IsComplete() => _isComplete;

        public override string GetStatus()
            => $"[{(_isComplete ? "X" : " ")}] {Name} ({Description})";

        public override string Serialize()
            => $"SimpleGoal|{Name}|{Description}|{Points}|{_isComplete}";
        
        public static SimpleGoal Deserialize(string[] parts)
        {
            var goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
            goal._isComplete = bool.Parse(parts[4]);
            return goal;
        }
    }
}
